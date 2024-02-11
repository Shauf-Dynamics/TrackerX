using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrackerX.Service.Musics;
using TrackerX.Services.Musics.Models;

namespace TrackerX.Web.Api.Endpoints.Client;

[ApiController]
[Authorize]
[Route("api/music-create")]
public class MusicCreateController : Controller
{
    private readonly IGenreService _genreService;

    public MusicCreateController(IGenreService genreService)
    {
        _genreService = genreService;
    }

    [HttpGet]
    [Route("v1/genres-list")]
    [ProducesResponseType(typeof(IEnumerable<GenresResult>), 200)]
    public async Task<IActionResult> Get()
    {
        var result = await _genreService.GetAllGenresAsync();

        return Ok(result);
    }
}
