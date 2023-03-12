using Microsoft.AspNetCore.Mvc;
using RadiDemoBackend.Responses;
using RadiDemoBackend.Services;

namespace RadiDemoBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RadiController : ControllerBase
    {
        private readonly ILogger<RadiController> _logger;
        private readonly IRadiService _radiService;

        public RadiController(ILogger<RadiController> logger, IRadiService radiService)
        {
            _logger = logger;
            _radiService = radiService;
        }

        [HttpGet("GetMeasurements")]
        public Task<DashboardResponse> Get()
        {
            return _radiService.GetDashBoard();
        }

        [HttpPost("Generate")]
        public Task Generate()
        {
            return _radiService.Genarate();
        }

        [HttpPost("Pay")]
        public Task Pay([FromBody] PayRequest payRequest)
        {
            return _radiService.Pay(payRequest.Id);
        }
    }
}