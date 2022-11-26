using BlazorAbbPoc.Server.Models;
using BlazorAbbPoc.Shared.Messages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Telerik.DataSource.Extensions;

namespace BlazorAbbPoc.Server.Services;

public class HierarchicalNameService : IHierarchicalNameService
{
    private readonly ILogger<HierarchicalNameService> _logger;
    private Dictionary<string, string> hierarchicalToIdCont = new();
    private Dictionary<string, string> idToHierarchicalCont = new();
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public HierarchicalNameService(ILogger<HierarchicalNameService> logger, IServiceScopeFactory serviceScopeFactory)
    {
        _logger = logger;
        _serviceScopeFactory = serviceScopeFactory;
    }

    public void Initialize()
    {
        hierarchicalToIdCont.Clear();
        idToHierarchicalCont.Clear();
        using (var scope = _serviceScopeFactory.CreateScope())
        {
            ApiDbContext dbContext = scope.ServiceProvider.GetService<ApiDbContext>();
            hierarchicalToIdCont.AddRange(dbContext.Devices.Include(d => d.Cabinet).ThenInclude(c => c.CabinetGroup).Select(x => KeyValuePair.Create(x.PlcDeviceId, $"LV01/{x.Cabinet.CabinetGroup.Name}/{x.Cabinet.Name}/{x.Name}")));
            idToHierarchicalCont.AddRange(dbContext.Devices.Include(d => d.Cabinet).ThenInclude(c => c.CabinetGroup).Select(x => KeyValuePair.Create($"LV01/{x.Cabinet.CabinetGroup.Name}/{x.Cabinet.Name}/{x.Name}", x.PlcDeviceId)));
        }
    }

    public string GetHierarchicalNameForPlcDeviceId(string plcDeviceId)
    {
        return hierarchicalToIdCont[plcDeviceId];
    }

    public string GetPlcDeviceIdForHierarchicalName(string hierarchicalName)
    {
        return idToHierarchicalCont[hierarchicalName];
    }
}
