using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TrackerX.Infrastructure;
using TrackerX.Service.Musics;
using TrackerX.Service.Musics.Models;
using TrackerX.Services.Musics;
using TrackerX.Services.Musics.Models;

namespace TrackerX.Web.Api.Gateway;

[ApiController]
[Route("api")]
[Authorize]
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
    [Route("v1/song")]
    public async Task<IActionResult> PostSong([FromBody] CreateSongModel model)
    {
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var userRoleName = User.FindFirstValue(ClaimTypes.Role)!;
        var result = await _songService.CreateAsync(model, userId, userRoleName);

        if (result.Status == StatusType.Success)
            return Created();
        else if (result.Status == StatusType.Invalid)
            return BadRequest(result.ErrorMessage);
        else
            return StatusCode(500);
    }

    [HttpPost]
    [Route("v1/custom-music")]
    public async Task<IActionResult> PostCustomMusic([FromBody] CreateCustomMusicModel model)
    {
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var userRoleName = User.FindFirstValue(ClaimTypes.Role)!;
        var result =  await _customMusicService.CreateAsync(model, userId, userRoleName);

        if (result.Status == StatusType.Success)
            return Created();
        else if (result.Status == StatusType.Invalid)
            return BadRequest(result.ErrorMessage);
        else
            return StatusCode(500);
    }

    [HttpDelete]
    [Route("v1/song")]
    public async Task<IActionResult> DeleteAsync(int songId)
    {
        return Ok();
    }
}
