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
            return _dbContext.Devices.Select(x => new DeviceDto
            {
                Id = x.Id,
                DeviceId = x.PlcDeviceId,
                DeviceTypeId = x.DeviceTypeId,
                CabinetId = x.CabinetId,
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
            dbDevice.MaxValue = device.MaxValue;
            dbDevice.PlcDeviceId = device.DeviceId;
            dbDevice.DeviceTypeId = device.DeviceTypeId;
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
        public async Task<IActionResult> AddDevice([FromBody] DeviceDto device)
        {
            Device dbDevice = new Device
            {
                MaxValue = device.MaxValue,
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

            //foreach (Device iterDevice in _dbContext.Devices.Include(dev => dev.Cabinet).ThenInclude(cab => cab.CabinetGroup).Include(dev => dev.DeviceTypeId))
            //{

            //}

            //foreach (CabinetGroup iterCabinetGroup in _dbContext.CabinetGroups)
            //{
            //    NavItemDto cabinetGroupNavItem = new NavItemDto { itemId = iterCabinetGroup.Name, pageType = "Navigation" };
            //    rootNavItem.items.Add(cabinetGroupNavItem);
            //    foreach (Cabinet iterCabinet in _dbContext.Cabinets.Where(x => x.CabinetGroupId == iterCabinetGroup.Id))
            //    {
            //        NavItemDto cabinetNavItem = new NavItemDto { itemId = iterCabinet.Name, pageType = "Navigation" };
            //        cabinetGroupNavItem.items.Add(cabinetNavItem);
            //        foreach (Device iterDevice in _dbContext.Devices.Include(x => x.DeviceTypeId).Where(x => x.CabinetId == iterCabinet.Id))
            //        {
            //            cabinetNavItem.items.Add(new NavItemDto { itemId = iterDevice.PlcDeviceId, pageType = iterDevice.DeviceType.Name });
            //        }
            //    }
            //}
            return rootNavItem;
        }
    }
}
