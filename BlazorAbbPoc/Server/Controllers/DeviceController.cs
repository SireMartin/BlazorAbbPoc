using BlazorAbbPoc.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
                CabinetGroupId = x.CabinetGroupId,
                CabinetId = x.CabinetId,
                CabinetPosition = x.CabinetPosition,
                MaxValue = x.MaxValue
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

        [HttpPut("device")]
        public async Task<IActionResult> UpdateDevice([FromBody] Shared.Messages.Device device)
        {
            Device? dbDevice = await _dbContext.Devices.FirstOrDefaultAsync(x => x.Id == device.Id);
            if (dbDevice is null)
            {
                return NotFound();
            }
            dbDevice.MaxValue = device.MaxValue;
            dbDevice.DeviceId = device.DeviceId;
            dbDevice.DeviceTypeId = device.DeviceTypeId;
            dbDevice.CabinetGroupId = device.CabinetGroupId;
            dbDevice.CabinetId = device.CabinetId;
            dbDevice.CabinetPosition = device.CabinetPosition;
            await _dbContext.SaveChangesAsync();
            return Ok(device);
        }

        [HttpDelete("device/{id:int}")]
        public async Task<IActionResult> UpdateDevice([FromRoute] int id)
        {
            Device? dbDevice = await _dbContext.Devices.FirstOrDefaultAsync(x => x.Id == id);
            if (dbDevice is null)
            {
                return NotFound();
            }
            _dbContext.Devices.Remove(dbDevice);
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpPost("device")]
        public async Task<IActionResult> AddDevice([FromBody] Shared.Messages.Device device)
        {
            Device dbDevice = new Device
            {
                MaxValue = device.MaxValue,
                DeviceId = device.DeviceId,
                DeviceTypeId = device.DeviceTypeId,
                //todo: implement
                //CabinetGroupId = device.CabinetGroupId,
                //CabinetId = device.CabinetId,
                CabinetGroupId = 1,
                CabinetId = 1,
                CabinetPosition = device.CabinetPosition
            };
            _dbContext.Devices.Add(dbDevice);
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(dbDevice.Id);
        }

        //[HttpGet("navigation")]
        //public Shared.Messages.NavItem GetNavigationInfo()
        //{
        //    foreach (CabinetGroup iterCabinetGroup in _dbContext.CabinetGroups)
        //    {
        //        foreach(Cabinet iterCabinet in _dbContext.Cabinets.Where(x => x.c
        //    }
        //}
    }
}
