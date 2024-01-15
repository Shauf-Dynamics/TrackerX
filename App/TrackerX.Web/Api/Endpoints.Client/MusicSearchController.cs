using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrackerX.Services.Musics;
using TrackerX.Services.Musics.Models;

namespace TrackerX.Web.Api.Endpoints.Client
{
    [ApiController]
    [Authorize]
    [Route("api/music/search")]
    public class MusicSearchController : Controller
    {
        private readonly IMusicSearchService _musicSearchService;

        public MusicSearchController(IMusicSearchService musicSearchService)
        {
            _musicSearchService = musicSearchService;
        }

        [HttpGet]
        [Route("v1")]
        [ProducesResponseType(typeof(IEnumerable<SongSearchResult>), 200)]
        public async Task<IActionResult> Get([FromQuery]string? searchText, [FromQuery]string searchBy)
        {
            var result = await _musicSearchService.GetMusicListBySearchCriterias(searchText, searchBy);

            return Ok(result);
        }

        [HttpGet]
        [Route("v1/details")]
        [ProducesResponseType(typeof(SongDetailsResult), 200)]
        public async Task<IActionResult> Get([FromQuery]int musicId)
        {
            var result = await _musicSearchService.GetMusicById(musicId);

            return Ok(result);
        }
    }
}
