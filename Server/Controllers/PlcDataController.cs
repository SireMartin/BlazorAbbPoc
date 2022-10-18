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

        public Shared.PlcData? Index()
        {
            return _dataService.PlcData;
        }
    }
}
