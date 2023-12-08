using Microsoft.AspNetCore.Mvc;
using TrackerX.Core.Services.Music;
using TrackerX.Core.Services.Musics.Models;

namespace TrackerX.Host.Api.Endpoints.Client
{
    [ApiController]
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
        [ProducesResponseType(typeof(IEnumerable<MusicSearchView>), 200)]
        public async Task<IActionResult> Get([FromQuery]string? searchText, [FromQuery]string? searchBy)
        {
            var result = await _musicSearchService.GetMusicListBySearchCriterias(searchText, searchBy);

            return Ok(result);
        }

        [HttpGet]
        [Route("v1/details")]
        [ProducesResponseType(typeof(MusicDetailsView), 200)]
        public async Task<IActionResult> Get(int musicId)
        {
            var result = await _musicSearchService.GetMusicById(musicId);

            return Ok(result);
        }
    }
}
