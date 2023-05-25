using Microsoft.AspNetCore.Mvc;
using Web.Application.Endpoints.Dashboard.Service;
using Web.Application.Endpoints.Dashboard.Models;

namespace Web.Application.Endpoints.Dashboard
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {        
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(DashboardResult), 200)]
        public async Task<IActionResult> Get()
        {
            var result = await _dashboardService.GetDashboardResult(default);

            return Ok(result);
        }
    }
}
