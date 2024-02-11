using Microsoft.AspNetCore.Mvc;
using TrackerX.Infrastructure;
using TrackerX.Service.Musics;
using TrackerX.Service.Musics.Models;
using TrackerX.Services.Musics;
using TrackerX.Services.Musics.Models;

namespace TrackerX.Web.Api.Gateway;

[ApiController]
[Route("api")]
public class MusicController : Controller
{
    private readonly ISongService _songService;
    private readonly ICustomMusicService _customMusicService;

    public MusicController(ISongService songService, ICustomMusicService customMusicService)
    {
        _songService = songService;
        _customMusicService = customMusicService;
    }

    [HttpPost]
    [Route("song/v1")]
    public async Task<IActionResult> PostSong([FromBody] CreateSongModel model)
    {
        var result = await _songService.CreateAsync(model);

        if (result.Status == StatusType.Success)
            return Created();
        else if (result.Status == StatusType.Invalid)
            return BadRequest(result.ErrorMessage);
        else
            return StatusCode(500);
    }

    [HttpPost]
    [Route("custom-music/v1")]
    public async Task<IActionResult> PostCustomMusic([FromBody] CreateCustomMusicModel model)
    {
        var result =  await _customMusicService.CreateAsync(model);

        if (result.Status == StatusType.Success)
            return Created();
        else if (result.Status == StatusType.Invalid)
            return BadRequest(result.ErrorMessage);
        else
            return StatusCode(500);
    }
}
