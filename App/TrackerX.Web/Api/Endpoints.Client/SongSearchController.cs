using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrackerX.Services.Musics;
using TrackerX.Services.Musics.Models;

namespace TrackerX.Web.Api.Endpoints.Client;

[ApiController]
[Authorize]
[Route("api/v1/song")]
public class SongSearchController : Controller
{
    private readonly ISongSearchService _songSearchService;

    public SongSearchController(ISongSearchService songSearchService)
    {
        _songSearchService = songSearchService;
    }

    [HttpGet]
    [Route("search")]
    [ProducesResponseType(typeof(IEnumerable<SongSearchResult>), 200)]
    public async Task<IActionResult> Get([FromQuery]string? searchText, [FromQuery]string searchBy)
    {
        var result = await _songSearchService.SearchSongsAsync(searchText, searchBy);

        return Ok(result);
    }

    [HttpGet]
    [Route("details")]
    [ProducesResponseType(typeof(SongDetailsResult), 200)]
    public async Task<IActionResult> Get([FromQuery]int songId)
    {
        var result = await _songSearchService.GetSongByIdAsync(songId);

        return Ok(result);
    }    
}
