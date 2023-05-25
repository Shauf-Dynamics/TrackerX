using Microsoft.AspNetCore.Mvc;
using Web.Application.Endpoints.RecordPage.Models;
using Web.Application.Endpoints.RecordPage.Service;

namespace Web.Application.Endpoints.RecordPage
{
    [ApiController]
    [Route("[controller]")]
    public class RecordPageController : ControllerBase
    {
        private readonly IRecordService _recordService;

        public RecordPageController(IRecordService recordService)
        {
            _recordService = recordService;
        }

        [HttpGet]        
        public async Task<IActionResult> Get([FromQuery] int id)
        {
            var result = await _recordService.GetRecord(id, default);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RecordCreateModel model)
        {
            await _recordService.CreateRecord(model);                      

            return Ok();
        }
    }
}
