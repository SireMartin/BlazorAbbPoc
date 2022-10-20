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
            return _dataService.PlcData.FirstOrDefault().Value;
        }
    }
}
