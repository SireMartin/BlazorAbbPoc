using BlazorAbbPoc.Server.Models;
using BlazorAbbPoc.Server.Services;
using BlazorAbbPoc.Shared;
using BlazorAbbPoc.Shared.Plc;
using Microsoft.AspNetCore.Mvc;

namespace BlazorAbbPoc.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlcDataController : ControllerBase
    {
        private readonly DataService _dataService;
        private readonly IActualValueService _actualValueService;
        private readonly IPlcMsgDispatcher _plcMsgDispatcher;

        public PlcDataController(DataService dataService, IActualValueService actualValueService, IPlcMsgDispatcher plcMsgDispatcher)
        {
            _dataService = dataService;
            _actualValueService = actualValueService;
            _plcMsgDispatcher = plcMsgDispatcher;
        }

        [HttpPost]
        public IActionResult Index([FromBody] AbbPlcMsg msg)
        {
            _plcMsgDispatcher.DispatchPlcMsg(msg);
            return Ok();
        }

        [HttpGet("chartdata")]
        public IEnumerable<ChartData> GetChartData()
        {
            if (_dataService.PlcTimedData.Count == 0)
            {
                return Array.Empty<ChartData>();
            }
            return _dataService.PlcTimedData.LastOrDefault().Value.Select(x => new ChartData { timestamp = x.Item1, plcMsg = x.Item2 });
        }

        [HttpGet("{lv}/{cg}/{c}/{d}")]
        public Shared.Messages.ActualValuesDto GetActualPlcDataForHierarchicalName(string lv, string cg, string c, string d)
        {
            return _actualValueService.GetActualValuesForHierarchicalName($"{lv}/{cg}/{c}/{d}");
        }
    }
}
