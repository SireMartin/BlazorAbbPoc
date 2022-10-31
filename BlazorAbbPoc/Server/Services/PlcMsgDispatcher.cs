using BlazorAbbPoc.Server.Models;
using BlazorAbbPoc.Shared.Plc;
using Microsoft.EntityFrameworkCore;

namespace BlazorAbbPoc.Server.Services;

public class PlcMsgDispatcher : IPlcMsgDispatcher
{
    private readonly IActualValueService _actualValueService;
    private readonly IHierarchicalNameService _hiIHierarchicalNameService;
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public PlcMsgDispatcher(IActualValueService actualValueService,
        IHierarchicalNameService hierarchicalNameService, IServiceScopeFactory serviceScopeFactory)
    {
        _actualValueService = actualValueService;
        _hiIHierarchicalNameService = hierarchicalNameService;
        _serviceScopeFactory = serviceScopeFactory;
    }

    public async Task Initialize()
    {
        using (var scope = _serviceScopeFactory.CreateScope())
        {
            ApiDbContext dbContext = scope.ServiceProvider.GetService<ApiDbContext>();
            foreach (var iter in dbContext.Devices)
            {
                _actualValueService.UpdateSettings(_hiIHierarchicalNameService.GetHierarchicalNameForPlcDeviceId(iter.PlcDeviceId), iter.MaxValue);
            }
        }
    }

    public async Task DispatchPlcMsg(AbbPlcMsg argMsg)
    {
        _actualValueService.UpdatePlcValues(_hiIHierarchicalNameService.GetHierarchicalNameForPlcDeviceId(argMsg.deviceId), argMsg);
        //if a message contains a setting value (f.e. ProtecA_L_I1), this has to be dispatched to the store because it is a change in config
        if (argMsg?.ProtA_L_I1 is not null)
        {
            _actualValueService.UpdateSettings(_hiIHierarchicalNameService.GetHierarchicalNameForPlcDeviceId(argMsg.deviceId), argMsg.ProtA_L_I1.Value);
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                ApiDbContext dbContext = scope.ServiceProvider.GetService<ApiDbContext>();
                Device? dbDevice = await dbContext.Devices.FirstOrDefaultAsync(x => x.PlcDeviceId == argMsg.deviceId);
                if (dbDevice is not null)
                {
                    dbDevice.MaxValue = argMsg.ProtA_L_I1.Value;
                    await dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
