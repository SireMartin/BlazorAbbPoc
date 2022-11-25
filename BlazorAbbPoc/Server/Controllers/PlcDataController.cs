using BlazorAbbPoc.Server.Models;
using BlazorAbbPoc.Server.Services;
using BlazorAbbPoc.Shared;
using BlazorAbbPoc.Shared.Plc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

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
        public ChartData GetChartData([FromRoute]string plcId, [FromQuery]DateTimeOffset? fromDate, [FromQuery]DateTimeOffset? toDate)
        {
            ChartData result = new ChartData
            {
                TimeSeriesData = _apiDbContext.Measurements.Include(x => x.Device)
                .Where(x => x.Device.PlcDeviceId == plcId && x.CreTimestamp > (fromDate == null ? DateTimeOffset.UtcNow.AddDays(-1) : fromDate.Value.ToUniversalTime()) 
                        && x.CreTimestamp <= (toDate == null ? DateTimeOffset.UtcNow : toDate.Value.ToUniversalTime()))
                .OrderBy(x => x.CreTimestamp).Select(x => new ChartData.TimeSeries
                {
                    timestamp = x.CreTimestamp,
                    l1V = x.L1nV,
                    l2V = x.L2nV,
                    l3V = x.L3nV,
                    l1A = x.L1A,
                    l2A = x.L2A,
                    l3A = x.L3A,
                    nA = x.nA
                })
            };
            Measurement? latestMeasurement = _apiDbContext.Measurements.Include(x => x.Device)
                .Where(x => x.Device.PlcDeviceId == plcId && x.CreTimestamp > (fromDate == null ? DateTimeOffset.UtcNow.AddDays(-1) : fromDate.Value.ToUniversalTime()) 
                        && x.CreTimestamp <= (toDate == null ? DateTimeOffset.UtcNow : toDate.Value.ToUniversalTime()))
                .OrderByDescending(x => x.CreTimestamp).FirstOrDefault();
            result.AggregatedData = new ChartData.Aggregated
            {
                l1ActE = latestMeasurement?.PActL1,
                l2ActE = latestMeasurement?.PActL2,
                l3ActE = latestMeasurement?.PActL3,
                totActE = latestMeasurement?.PAppTotal,
                l1ReactE = latestMeasurement?.pReactL1,
                l2ReactE = latestMeasurement?.pReactL2,
                l3ReactE = latestMeasurement?.pReactL3,
                totReactE = latestMeasurement?.PReactTotal,
                l1AppE = latestMeasurement?.PAppL1,
                l2AppE = latestMeasurement?.PAppL2,
                l3AppE = latestMeasurement?.PAppL3,
                totAppE = latestMeasurement?.PAppTotal
            };
            return result;
        }

        [HttpGet("{lv}/{cg}/{c}/{d}")]
        public Shared.Messages.ActualValuesDto GetActualPlcDataForHierarchicalName(string lv, string cg, string c, string d)
        {
            return _actualValueService.GetActualValuesForHierarchicalName($"{lv}/{cg}/{c}/{d}");
        }
    }
}
