using Domain;
using Microsoft.AspNetCore.Mvc;
using Web.Application.Endpoints.RecordList.Models;
using Web.Application.Endpoints.RecordList.Service;

namespace Web.Application.Endpoints.RecordList
{
    [ApiController]
    [Route("[controller]")]
    public class RecordListController : ControllerBase
    {        
        //private readonly ILogger<RecordListController> _logger;
        private readonly IRecordListService _recordListService;

        public RecordListController(IRecordListService recordListService)
        {
            _recordListService = recordListService;
        }

        [HttpGet, Route("v1")]
        [ProducesResponseType(typeof(RecordListResult), 200)]
        public async Task<IActionResult> Get()
        {
            var result = await _recordListService.GetRecordList(default);

            return Ok(result);
        }
    }
}