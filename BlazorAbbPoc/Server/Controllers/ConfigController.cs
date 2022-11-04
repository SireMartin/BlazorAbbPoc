using BlazorAbbPoc.Server.Models;
using BlazorAbbPoc.Server.Services;
using BlazorAbbPoc.Shared.Messages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorAbbPoc.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigController : ControllerBase
    {
        private readonly ApiDbContext _dbContext;
        private readonly IActualValueService _actualValueService;
        private readonly IHierarchicalNameService _hierarchicalNameService;

        public ConfigController(ApiDbContext dbContext, IActualValueService actualValueService, IHierarchicalNameService hierarchicalNameService)
        {
            _dbContext = dbContext;
            _actualValueService = actualValueService;
            _hierarchicalNameService = hierarchicalNameService;
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
            //the hierarchicalnames could have been changed so reinitialize the hierarchicalname service
            await _hierarchicalNameService.Initialize();
            _actualValueService.UpdateSettings(_hierarchicalNameService.GetHierarchicalNameForPlcDeviceId(dbDevice.PlcDeviceId), device.MaxValue);
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
                CabinetId = device.CabinetId,
                CabinetPosition = device.CabinetPosition
            };
            _dbContext.Devices.Add(dbDevice);
            try
            {
                await _dbContext.SaveChangesAsync();
                //the hierarchicalnames could have been changed so reinitialize the hierarchicalname service
                await _hierarchicalNameService.Initialize();
                _actualValueService.UpdateSettings(_hierarchicalNameService.GetHierarchicalNameForPlcDeviceId(dbDevice.PlcDeviceId), device.MaxValue);
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
            //explicitly add the mother of all LV01 (so no need to change frontend code)
            NavItemDto rootNavItem = new NavItemDto { itemId = "LV01" };
            rootNavItem.items = _dbContext.CabinetGroups.Include(cg => cg.Cabinets).ThenInclude(c => c.Devices).ThenInclude(d => d.DeviceType).Select(cg => new NavItemDto
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
            });
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

        [HttpPut("cabinet")]
        public async Task<IActionResult> UpdateCabinet([FromBody] CabinetDto cabinet)
        {
            Cabinet? dbCabinet = await _dbContext.Cabinets.FirstOrDefaultAsync(x => x.Id == cabinet.Id);
            if (dbCabinet is null)
            {
                return NotFound();
            }
            dbCabinet.Name = cabinet.Name;
            dbCabinet.CabinetGroupId = cabinet.CabinetGroupId;
            await _dbContext.SaveChangesAsync();
            //the hierarchicalnames could have been changed so reinitialize the hierarchicalname service
            await _hierarchicalNameService.Initialize();
            return Ok(cabinet);
        }

        [HttpDelete("cabinet/{id:int}")]
        public async Task<IActionResult> DeleteCabinet([FromRoute] int id)
        {
            Cabinet? dbCabinet = await _dbContext.Cabinets.FirstOrDefaultAsync(x => x.Id == id);
            if (dbCabinet is null)
            {
                return NotFound();
            }
            _dbContext.Cabinets.Remove(dbCabinet);
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

        [HttpPost("cabinet")]
        public async Task<IActionResult> AddCabinet([FromBody] CabinetDto cabinet)
        {
            Cabinet dbCabinet = new Cabinet
            {
                Name = cabinet.Name,
                CabinetGroupId = cabinet.CabinetGroupId
            };
            _dbContext.Cabinets.Add(dbCabinet);
            try
            {
                await _dbContext.SaveChangesAsync();
                //the hierarchicalnames could have been changed so reinitialize the hierarchicalname service
                await _hierarchicalNameService.Initialize();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(dbCabinet.Id);
        }

        [HttpPut("cabinetgroup")]
        public async Task<IActionResult> UpdateCabinetGroup([FromBody] CabinetGroupDto cabinetGroup)
        {
            CabinetGroup? dbCabinetGroup = await _dbContext.CabinetGroups.FirstOrDefaultAsync(x => x.Id == cabinetGroup.Id);
            if (dbCabinetGroup is null)
            {
                return NotFound();
            }
            dbCabinetGroup.Name = cabinetGroup.Name;
            await _dbContext.SaveChangesAsync();
            //the hierarchicalnames could have been changed so reinitialize the hierarchicalname service
            await _hierarchicalNameService.Initialize();
            return Ok(cabinetGroup);
        }

        [HttpDelete("cabinetgroup/{id:int}")]
        public async Task<IActionResult> DeleteCabinetGroup([FromRoute] int id)
        {
            CabinetGroup? dbCabinetGroup = await _dbContext.CabinetGroups.FirstOrDefaultAsync(x => x.Id == id);
            if (dbCabinetGroup is null)
            {
                return NotFound();
            }
            _dbContext.CabinetGroups.Remove(dbCabinetGroup);
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

        [HttpPost("cabinetgroup")]
        public async Task<IActionResult> AddCabinetGroup([FromBody] CabinetGroupDto cabinetGroup)
        {
            CabinetGroup dbCabinetGroup = new CabinetGroup
            {
                Name = cabinetGroup.Name,
            };
            _dbContext.CabinetGroups.Add(dbCabinetGroup);
            try
            {
                await _dbContext.SaveChangesAsync();
                //the hierarchicalnames could have been changed so reinitialize the hierarchicalname service
                await _hierarchicalNameService.Initialize();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(dbCabinetGroup.Id);
        }
    }
}
