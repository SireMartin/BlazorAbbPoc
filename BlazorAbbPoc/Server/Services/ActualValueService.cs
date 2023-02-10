using BlazorAbbPoc.Server.Configurations;
using BlazorAbbPoc.Shared.Messages;
using BlazorAbbPoc.Shared.Plc;
using Microsoft.Extensions.Options;

namespace BlazorAbbPoc.Server.Services;

public class ActualValueService : IActualValueService
{
    private static object _lockObj = new(); //this service must remain singleton
    private Dictionary<string, ActualValuesDto> container = new(); //key is for example LV01/AutoBoxes/K0-3/MainBreaker
    private readonly AnomalyDetectionOptions anomalyDetectionOptions;

    public ActualValueService(IOptions<AnomalyDetectionOptions> argOptions) 
    {
        anomalyDetectionOptions = argOptions.Value;
    }

    public bool UpdatePlcValues(string key, AbbPlcMsg abbPlcMsg)
    {
        bool gapDetected = false;
        //todo: will always contain key because the PlcMsgDispatcher does an intialization
        if (!container.ContainsKey(key))
        {
            container.Add(key, new ActualValuesDto());
        }
        else if (container[key].creTimestamp is not null && 
            DateTimeOffset.UtcNow.ToUnixTimeSeconds() - container[key].creTimestamp.Value.ToUnixTimeSeconds() > anomalyDetectionOptions.GapThresholdSeconds)
        { 
            gapDetected = true;
        }       
        lock (_lockObj)
        {
            //update all values except the settings value
            container[key].l1A = abbPlcMsg.l1A;
            container[key].l2A = abbPlcMsg.l2A;
            container[key].l3A = abbPlcMsg.l3A;
            container[key].l1l2V = abbPlcMsg.l1A;
            container[key].l2l3V = abbPlcMsg.l2l3V;
            container[key].l3l1V = abbPlcMsg.l3l1V;
            container[key].l1nV = abbPlcMsg.l1nV;
            container[key].l2nV = abbPlcMsg.l2nV;
            container[key].l3nV = abbPlcMsg.l3nV;
            container[key].pActTotal = abbPlcMsg.pActTotal;
            container[key].pReactTotal = abbPlcMsg.pReactTotal;
            container[key].pAppTotal = abbPlcMsg.pActTotal;
            container[key].frq = abbPlcMsg.frq;
            container[key].creTimestamp = DateTimeOffset.UtcNow;
        }
        return gapDetected;
    }

    public void UpdateSettings(string key, int protA_L_I1)
    {
        if (!container.ContainsKey(key))
        {
            container.Add(key, new ActualValuesDto());
        }
        lock(_lockObj)
        {
            container[key].protA_L_I1 = protA_L_I1;
        }
    }

    public void UpdateLatestTimestamp(string key, DateTimeOffset? latestTime) 
    { 
        if (latestTime is null)
        {
            //not ever wat a measuremen made (while initializing in the plcmessagedispatcher)
            return;
        }
        if (!container.ContainsKey(key))
        {
            container.Add(key, new ActualValuesDto());
        }
        lock (_lockObj)
        {
            container[key].creTimestamp = latestTime;
        }
    }

    public ActualValuesDto GetActualValuesForHierarchicalName(string argHierarchicalName)
    {
        lock(_lockObj)
        {
            return container[argHierarchicalName];
        }
    }
}
