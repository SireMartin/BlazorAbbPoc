using BlazorAbbPoc.Server.Models;
using BlazorAbbPoc.Shared.Messages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Telerik.DataSource.Extensions;

namespace BlazorAbbPoc.Server.Services;

public class HierarchicalNameService : IHierarchicalNameService
{
    private readonly ILogger<HierarchicalNameService> _logger;
    private Dictionary<string, string> container = new();
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public HierarchicalNameService(ILogger<HierarchicalNameService> logger, IServiceScopeFactory serviceScopeFactory)
    {
        _logger = logger;
        _serviceScopeFactory = serviceScopeFactory;
    }

    public void Initialize()
    {
        container.Clear();
        using (var scope = _serviceScopeFactory.CreateScope())
        {
            ApiDbContext dbContext = scope.ServiceProvider.GetService<ApiDbContext>();
            container.AddRange(dbContext.Devices.Include(d => d.Cabinet).ThenInclude(c => c.CabinetGroup).Select(x => KeyValuePair.Create(x.PlcDeviceId, $"LV01/{x.Cabinet.CabinetGroup.Name}/{x.Cabinet.Name}/{x.Name}")));
        }
    }

    public string GetHierarchicalNameForPlcDeviceId(string plcDeviceId)
    {
        return container[plcDeviceId];
    }
}
