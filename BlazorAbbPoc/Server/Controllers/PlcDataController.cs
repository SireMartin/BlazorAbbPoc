using BlazorAbbPoc.Server.Models;
using BlazorAbbPoc.Server.Services;
using BlazorAbbPoc.Shared;
using BlazorAbbPoc.Shared.Plc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorAbbPoc.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlcDataController : ControllerBase
    {
        private readonly ApiDbContext _apiDbContext;
        private readonly IActualValueService _actualValueService;
        private readonly IPlcMsgDispatcher _plcMsgDispatcher;

        public PlcDataController(IActualValueService actualValueService, IPlcMsgDispatcher plcMsgDispatcher, ApiDbContext apiDbContext)
        {
            _actualValueService = actualValueService;
            _plcMsgDispatcher = plcMsgDispatcher;
            _apiDbContext = apiDbContext;
        }

        [HttpPost]
        public IActionResult Index([FromBody] AbbPlcMsg msg)
        {
            _plcMsgDispatcher.DispatchPlcMsg(msg);
            return Ok();
        }

        [HttpGet("chartdata/{plcId}")]
        public IEnumerable<ChartData> GetChartData(string plcId)
        {
            return _apiDbContext.Measurements.Include(x => x.Device).Where(x => x.Device.PlcDeviceId == plcId).Select(x => new ChartData
            {
                timestamp = x.CreTimestamp,
                l1Voltage = x.L1nV,
                l2Voltage = x.L2nV,
                l3Voltage = x.L3nV
            });
        }

        [HttpGet("{lv}/{cg}/{c}/{d}")]
        public Shared.Messages.ActualValuesDto GetActualPlcDataForHierarchicalName(string lv, string cg, string c, string d)
        {
            return _actualValueService.GetActualValuesForHierarchicalName($"{lv}/{cg}/{c}/{d}");
        }
    }
}
