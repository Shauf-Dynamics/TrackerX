using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrackerX.Core.Services.Albums;
using TrackerX.Core.Services.Albums.Models;

namespace TrackerX.Web.Api.Gateway;

[ApiController]
[Authorize(Policy="admin")]
[Route("api/[controller]")]
public class AlbumController : ControllerBase
{
    private readonly IAlbumService _albumService;

    public AlbumController(IAlbumService albumService)
    {
        _albumService = albumService;
    }

    [HttpPost]
    [Route("v1/create")]        
    public async Task<IActionResult> Post([FromBody]CreateAlbumModel model)
    {
        await _albumService.Create(model);

        return Ok();
    }

    [HttpGet]
    [Route("v1")]
    public async Task<IActionResult> Get([FromQuery] int id)
    {
        var result = await _albumService.GetAlbumById(id);

        return Ok(result);
    }
}
