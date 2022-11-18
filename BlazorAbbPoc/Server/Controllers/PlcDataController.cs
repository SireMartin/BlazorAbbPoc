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
                l1V = x.L1nV,
                l2V = x.L2nV,
                l3V = x.L3nV,
                l1A = x.L1A,
                l2A = x.L2A,
                l3A = x.L3A,
                nA = x.nA,
                l1ActE = x.PActL1,
                l2ActE = x.PActL2,
                l3ActE = x.PActL3,
                totActE = x.PAppTotal,
                l1ReactE = x.pReactL1,
                l2ReactE = x.pReactL2,
                l3ReactE = x.pReactL3,
                totReactE = x.PReactTotal,
                l1AppE = x.PAppL1,
                l2AppE = x.PAppL2,
                l3AppE = x.PAppL3,
                totAppE = x.PAppTotal
            });
        }

        [HttpGet("{lv}/{cg}/{c}/{d}")]
        public Shared.Messages.ActualValuesDto GetActualPlcDataForHierarchicalName(string lv, string cg, string c, string d)
        {
            return _actualValueService.GetActualValuesForHierarchicalName($"{lv}/{cg}/{c}/{d}");
        }
    }
}
