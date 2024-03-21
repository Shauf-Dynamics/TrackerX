using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TrackerX.Service.Musics;
using TrackerX.Service.Musics.Models;

namespace TrackerX.Web.Api.Endpoints.Client;

[ApiController]
[Authorize]
[Route("api/v1/music-profile")]
public class MyMusicController : Controller
{
    private readonly IMusicProfileService _musicProfileService;

    public MyMusicController(IMusicProfileService musicProfileService)
    {
        _musicProfileService = musicProfileService;
    }

    [HttpGet]
    [Route("search")]
    [ProducesResponseType(typeof(IEnumerable<MusicProfileView>), 200)]
    public async Task<IActionResult> Get([FromQuery] MusicProfileSearchModel searchModel)
    {
        int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var result = await _musicProfileService.GetUserOwnMusic(searchModel, userId);

        return Ok(result);
    }
}
