using Microsoft.AspNetCore.Mvc;
using TrackerX.Core.Services.Bands;
using TrackerX.Core.Services.Bands.Models;

namespace TrackerX.Host.Api.Gateway
{
    [ApiController]
    [Route("api/[controller]")]
    public class BandController : ControllerBase
    {        
        private readonly IBandService _bandService;

        public BandController(IBandService bandService)
        {
            _bandService = bandService;
        }

        [HttpGet] 
        [Route("v1/list")]
        [ProducesResponseType(typeof(BandsViewModel), 200)]        
        public async Task<IActionResult> Get([FromQuery] int pageSize)
        {
            var result = await _bandService.GetBandsByCriterias(new BandsSearchParams(pageSize, string.Empty));

            return Ok(result);
        }

        [HttpGet]
        [Route("v1/list/search")]
        [ProducesResponseType(typeof(BandsViewModel), 200)]        
        public async Task<IActionResult> Get([FromQuery]int pageSize, [FromQuery] string startsWith)
        {
            var result = await _bandService.GetBandsByCriterias(new BandsSearchParams(pageSize, startsWith));

            return Ok(result);
        }

        [HttpPost]
        [Route("v1/create")]
        public async Task<IActionResult> Post([FromBody]CreateBandModel model)
        {
            await _bandService.CreateBand(model);

            return Ok();
        }

        [HttpPut]
        [Route("v1/rename")]
        public async Task<IActionResult> Put([FromQuery]int id, [FromBody]string model)
        {
            await _bandService.RenameBand(id, model);

            return Ok();
        }
    }
}
