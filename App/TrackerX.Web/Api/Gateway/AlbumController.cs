using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrackerX.Core.Services.Albums;
using TrackerX.Core.Services.Albums.Models;
using TrackerX.Service.Albums.Models;

namespace TrackerX.Web.Api.Gateway;

[ApiController]
[Route("api/album")]
public class AlbumController : ControllerBase
{
    private readonly IAlbumService _albumService;

    public AlbumController(IAlbumService albumService)
    {
        _albumService = albumService;
    }

    [HttpGet]
    [Route("v1/search")]
    public async Task<IActionResult> Get([FromQuery] int pageSize, [FromQuery] string startsWith)
    {
        var result = await _albumService.GetAlbumsByCriteriasAsync(new AlbumSearchParams(pageSize, startsWith));

        return Ok(result);
    }

    [HttpGet]
    [Route("v1/byBand")]
    public async Task<IActionResult> GetByBand([FromQuery] int bandId)
    {
        var result = await _albumService.GetAlbumsByBandAsync(bandId);

        return Ok(result);
    }

    [HttpPost]
    [Authorize(Policy = "admin")]
    [Route("v1/create")]        
    public async Task<IActionResult> Post([FromBody]CreateAlbumModel model)
    {
        await _albumService.CreateAsync(model);

        return Ok();
    }    
}
