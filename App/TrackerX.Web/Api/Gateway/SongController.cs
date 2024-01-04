using Microsoft.AspNetCore.Mvc;
using TrackerX.Core.Services.Music;
using TrackerX.Core.Services.Musics;
using TrackerX.Core.Services.Musics.Models;

namespace TrackerX.Web.Api.Gateway
{
    [ApiController]
    [Route("api/[controller]")]
    public class SongController : Controller
    {
        private readonly IMusicService _musicService;
        private readonly IMusicSearchService _musicSearchService;

        public SongController(IMusicService musicService, IMusicSearchService musicSearchService)
        {
            _musicService = musicService;
            _musicSearchService = musicSearchService;
        }

        [HttpPost]
        [Route("v1/create")]
        public async Task<IActionResult> Post([FromBody] CreateMusicModel model)
        {
            await _musicService.Create(model);

            return Ok();
        }

        [HttpPut]
        [Route("v1/update")]
        public async Task<IActionResult> Put([FromQuery] int songId, [FromBody] string songName)
        {
            await _musicService.RenameSong(songId, songName);

            return Ok();
        }

        [HttpPut]
        [Route("v1/{songId:int}/assign-album/{albumId:int}")]
        public async Task<IActionResult> AssignAlbum(int songId, int albumId)
        {
            await _musicService.AssingToAlbum(albumId, songId);

            return Ok();
        }
    }
}
