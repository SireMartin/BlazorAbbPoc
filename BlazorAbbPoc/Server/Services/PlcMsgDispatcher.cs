using BlazorAbbPoc.Server.Models;
using BlazorAbbPoc.Shared.Plc;
using Microsoft.EntityFrameworkCore;

namespace BlazorAbbPoc.Server.Services;

public class PlcMsgDispatcher : IPlcMsgDispatcher
{
    private readonly IActualValueService _actualValueService;
    private readonly IHierarchicalNameService _hiIHierarchicalNameService;
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly ILogger<PlcMsgDispatcher> _logger;

    public PlcMsgDispatcher(IActualValueService actualValueService, IHierarchicalNameService hierarchicalNameService, IServiceScopeFactory serviceScopeFactory, ILogger<PlcMsgDispatcher> logger)
    {
        _actualValueService = actualValueService;
        _hiIHierarchicalNameService = hierarchicalNameService;
        _serviceScopeFactory = serviceScopeFactory;
        _logger = logger;
    }

    public void Initialize()
    {
        using (var scope = _serviceScopeFactory.CreateScope())
        {
            ApiDbContext dbContext = scope.ServiceProvider.GetService<ApiDbContext>();
            //while initializing the protALI1, also fetch the latest measurement from the db for gap detection (while this back-end was down)
            foreach (var iter in dbContext.Devices)
            {
                _actualValueService.UpdateSettings(_hiIHierarchicalNameService.GetHierarchicalNameForPlcDeviceId(iter.PlcDeviceId), iter.MaxValue);
                _actualValueService.UpdateLatestTimestamp(_hiIHierarchicalNameService.GetHierarchicalNameForPlcDeviceId(iter.PlcDeviceId), dbContext.Measurements.Where(x => x.DeviceId == iter.Id)?.Max(x => x.CreTimestamp));
            }
        }
    }

    public async Task DispatchPlcMsg(AbbPlcMsg argMsg)
    {
        //update actual values for gauge visualisation
        string hierarchicalDeviceName = _hiIHierarchicalNameService.GetHierarchicalNameForPlcDeviceId(argMsg.deviceId);
        bool gapDetected = _actualValueService.UpdatePlcValues(hierarchicalDeviceName, argMsg);

        using (var scope = _serviceScopeFactory.CreateScope())
        {
            ApiDbContext dbContext = scope.ServiceProvider.GetService<ApiDbContext>();
            Device? dbDevice = await dbContext.Devices.FirstOrDefaultAsync(x => x.PlcDeviceId == argMsg.deviceId);
            if (dbDevice is not null)
            {

                //if a message contains a setting value (f.e. ProtecA_L_I1), this has to be dispatched to the store because it is a change in config
                if (argMsg?.ProtA_L_I1 is not null && _actualValueService.GetActualValuesForHierarchicalName(hierarchicalDeviceName).protA_L_I1 != argMsg.ProtA_L_I1)
                {
                    _logger.LogInformation($"protA_L_I1 changed from {_actualValueService.GetActualValuesForHierarchicalName(hierarchicalDeviceName).protA_L_I1} to {argMsg.ProtA_L_I1} for device {argMsg.deviceId} => persist to database");
                    _actualValueService.UpdateSettings(_hiIHierarchicalNameService.GetHierarchicalNameForPlcDeviceId(argMsg.deviceId), argMsg.ProtA_L_I1.Value);
                    dbDevice.MaxValue = argMsg.ProtA_L_I1.Value;
                }

                //if a gap was detected, add the null value so the graph knows how to plot
                if (gapDetected)
                {
                    dbContext.Measurements.Add(new Measurement
                    {
                        DeviceId = dbDevice.Id,
                        CreTimestamp = DateTimeOffset.UtcNow
                    });
                }

                //persist msg to database for graph visualisation
                dbContext.Measurements.Add(new Measurement
                {
                    DeviceId = dbDevice.Id,
                    L1A = argMsg.l1A,
                    L2A = argMsg.l2A,
                    L3A = argMsg.l3A,
                    nA = argMsg.NeA,
                    L1nV = argMsg.l1nV,
                    L2nV = argMsg.l2nV,
                    L3nV = argMsg.l3nV,
                    L1l2V = argMsg.l1l2V,
                    L2l3V = argMsg.l2l3V,
                    L3l1V = argMsg.l3l1V,
                    PActL1 = argMsg.pActL1,
                    PActL2 = argMsg.pActL2,
                    PActL3 = argMsg.pActL3,
                    PActTotal = argMsg.pActTotal,
                    pReactL1 = argMsg.pReactL1,
                    pReactL2 = argMsg.pReactL2,
                    pReactL3 = argMsg.pReactL3,
                    PReactTotal= argMsg.pReactTotal,
                    PAppL1 = argMsg.pAppL1,
                    PAppL2 = argMsg.pAppL2,
                    PAppL3 = argMsg.pAppL3,
                    PAppTotal = argMsg.pActTotal,
                    Frq = argMsg.frq,
                    ProtA_L_I1 = argMsg.ProtA_L_I1,
                    CreTimestamp = DateTimeOffset.UtcNow
                });
            }
            await dbContext.SaveChangesAsync();
        }
    }
}
