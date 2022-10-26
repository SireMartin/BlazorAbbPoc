using BlazorAbbPoc.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlazorAbbPoc.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private readonly ApiDbContext _dbContext;

        public DeviceController(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("devices")]
        public IEnumerable<Shared.Messages.Device> GetAllDevices()
        {
            return _dbContext.Devices.Select(x => new Shared.Messages.Device
            {
                Id = x.Id,
                DeviceId = x.DeviceId,
                DeviceTypeId = x.DeviceTypeId,
                CabinetGroupId= x.CabinetGroupId,
                CabinetId= x.CabinetId,
                CabinetPosition= x.CabinetPosition,
                MaxValue= x.MaxValue
            });
        }

        [HttpGet("devicetypes")]
        public IEnumerable<Shared.Messages.DeviceType> GetAllDeviceTypes()
        {
            return _dbContext.DeviceTypes.Select(x => new Shared.Messages.DeviceType
            {
                Id = x.Id,
                Name = x.Name
            });
        }
    }
}
