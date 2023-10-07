﻿using Microsoft.AspNetCore.Mvc;
using TrackerX.Core.Services.Songs;
using TrackerX.Core.Services.Songs.Models;

namespace TrackerX.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SongController : Controller
    {
        private readonly ISongService _songService;

        public SongController(ISongService songService)
        {
            _songService = songService;
        }

        [HttpGet]
        [Route("v1/list")]
        [ProducesResponseType(typeof(IEnumerable<SongViewModel>), 200)]
        public async Task<IActionResult> Get([FromQuery] int bandId)
        {
            var result = await _songService.GetSongsByBandId(bandId);

            return Ok(result);
        }

        [HttpPost]
        [Route("v1/create")]
        public async Task<IActionResult> Post([FromBody] CreateSongModel model)
        {
            await _songService.Create(model);

            return Ok();
        }

        [HttpPut]
        [Route("v1/update")]
        public async Task<IActionResult> Put([FromQuery] int songId, [FromBody] string songName)
        {
            await _songService.RenameSong(songId, songName);

            return Ok();
        }

        [HttpPut]
        [Route("v1/{songId:int}/assign-album/{albumId:int}")]
        public async Task<IActionResult> AssignAlbum(int songId, int albumId)
        {
            await _songService.AssingToAlbum(albumId, songId);

            return Ok();
        }
    }
}
