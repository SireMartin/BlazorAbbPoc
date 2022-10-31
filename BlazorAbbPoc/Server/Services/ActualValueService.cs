using BlazorAbbPoc.Shared.Messages;
using BlazorAbbPoc.Shared.Plc;

namespace BlazorAbbPoc.Server.Services;

public class ActualValueService : IActualValueService
{
    private Dictionary<string, ActualValuesDto> container = new(); //key is for example LV01/AutoBoxes/K0-3/MainBreaker

    public void UpdatePlcValues(string key, AbbPlcMsg abbPlcMsg)
    {
        if (!container.ContainsKey(key))
        {
            container.Add(key, new ActualValuesDto());
        }
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
    }

    public void UpdateSettings(string key, int protA_L_I1)
    {
        if (!container.ContainsKey(key))
        {
            container.Add(key, new ActualValuesDto());
        }
        container[key].protA_L_I1 = protA_L_I1;
    }

    public ActualValuesDto GetActualValuesForHierarchicalName(string argHierarchicalName)
    {
        return container[argHierarchicalName];
    }
}
