using BlazorAbbPoc.Server.Models;
using BlazorAbbPoc.Shared.Messages;
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
        public IEnumerable<DeviceDto> GetAllDevices()
        {
            return _dbContext.Devices.Include(x => x.Cabinet).Select(x => new DeviceDto
            {
                Id = x.Id,
                Name = x.Name,
                DeviceId = x.PlcDeviceId,
                DeviceTypeId = x.DeviceTypeId,
                CabinetId = x.CabinetId,
                //cabinet group id is only provided in the get call dto, but not part of the device model
                CabinetGroupId = x.Cabinet.CabinetGroupId,
                CabinetPosition = x.CabinetPosition,
                MaxValue = x.MaxValue
            });
        }

        [HttpGet("devicetypes")]
        public IEnumerable<DeviceTypeDto> GetAllDeviceTypes()
        {
            return _dbContext.DeviceTypes.Select(x => new DeviceTypeDto
            {
                Id = x.Id,
                Name = x.Name
            });
        }

        [HttpPut("device")]
        public async Task<IActionResult> UpdateDevice([FromBody] DeviceDto device)
        {
            Device? dbDevice = await _dbContext.Devices.FirstOrDefaultAsync(x => x.Id == device.Id);
            if (dbDevice is null)
            {
                return NotFound();
            }
            //no cabinet group id
            dbDevice.MaxValue = device.MaxValue;
            dbDevice.Name = device.Name;
            dbDevice.PlcDeviceId = device.DeviceId;
            dbDevice.DeviceTypeId = device.DeviceTypeId;
            dbDevice.CabinetId = device.CabinetId;
            dbDevice.CabinetPosition = device.CabinetPosition;
            await _dbContext.SaveChangesAsync();
            return Ok(device);
        }

        [HttpDelete("device/{id:int}")]
        public async Task<IActionResult> DeleteDevice([FromRoute] int id)
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
        public async Task<IActionResult> AddDevice([FromBody] DeviceDto device)
        {
            Device dbDevice = new Device
            {
                MaxValue = device.MaxValue,
                Name = device.Name,
                PlcDeviceId = device.DeviceId,
                DeviceTypeId = device.DeviceTypeId,
                //todo: implement
                //CabinetId = device.CabinetId,
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

        [HttpGet("navigation")]
        public NavItemDto GetNavigationInfo()
        {
            NavItemDto rootNavItem = new NavItemDto
            {
                items = _dbContext.CabinetGroups.Include(cg => cg.Cabinets).ThenInclude(c => c.Devices).ThenInclude(d => d.DeviceType).Select(cg => new NavItemDto
                {
                    itemId = cg.Name,
                    pageType = "Navigation",
                    items = cg.Cabinets.Select(c => new NavItemDto
                    {
                        itemId = c.Name,
                        pageType = "Navigation",
                        items = c.Devices.Select(d => new NavItemDto
                        {
                            itemId = d.Name,
                            pageType = d.DeviceType.Name
                        })
                    })
                })
            };
            return rootNavItem;
        }

        [HttpGet("cabinets")]
        public IEnumerable<CabinetDto> GetAllCabinets()
        {
            return _dbContext.Cabinets.Select(x => new CabinetDto
            {
                Id = x.Id,
                CabinetGroupId = x.CabinetGroupId,
                Name = x.Name
            });
        }

        [HttpGet("cabinetgroups")]
        public IEnumerable<CabinetGroupDto> GetAllCabinetGroups()
        {
            return _dbContext.CabinetGroups.Select(x => new CabinetGroupDto
            {
                Id = x.Id,
                Name = x.Name
            });
        }
    }
}
