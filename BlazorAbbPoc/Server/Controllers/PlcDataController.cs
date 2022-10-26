using BlazorAbbPoc.Server.Models;
using BlazorAbbPoc.Shared;
using Microsoft.AspNetCore.Mvc;

namespace BlazorAbbPoc.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlcDataController : ControllerBase
    {
        private readonly Services.DataService _dataService;

        public PlcDataController(Services.DataService dataService)
        {
            _dataService = dataService;
        }

        [HttpPost("{id}")]
        public IActionResult Index([FromRoute] string id, [FromBody] AbbPlcMsg msg)
        {
            _dataService.PlcData[id] = msg;
            if (!_dataService.PlcTimedData.ContainsKey(id))
            {
                _dataService.PlcTimedData[id] = new List<(DateTime, AbbPlcMsg)>();
            }
            _dataService.PlcTimedData[id].Add((DateTime.Now, msg));
            return Ok();
        }

        [HttpGet]
        public AbbPlcMsg Get()
        {
            return _dataService.PlcData.LastOrDefault().Value;
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

        [HttpGet("blog")]
        public IEnumerable<Device> GetAllBlogs([FromServices] ApiDbContext apiDbContext)
        {
            return apiDbContext.Devices.Select(x => x);
        }
    }
}
