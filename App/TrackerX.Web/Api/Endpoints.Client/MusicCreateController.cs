using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrackerX.Core.Services.Music;
using TrackerX.Core.Services.Musics.Models;

namespace TrackerX.Web.Api.Endpoints.Client
{    
    [Authorize]
    [ApiController]
    [Route("api/music/create")]
    public class MusicCreateController : Controller
    {
        private readonly IMusicSearchService _musicSearchService;

        public MusicCreateController(IMusicSearchService musicSearchService)
        {
            _musicSearchService = musicSearchService;
        }

        [HttpGet]
        [Route("v1/genres")]
        [ProducesResponseType(typeof(IEnumerable<GenresResult>), 200)]
        public async Task<IActionResult> Get()
        {
            var result = await _musicSearchService.GetAllGenres();

            return Ok(result);
        }
    }
}
