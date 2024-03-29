﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrackerX.Services.Bands;
using TrackerX.Services.Bands.Models;

namespace TrackerX.Web.Api.Gateway;

[ApiController]
[Route("api/band")]
public class BandController : ControllerBase
{        
    private readonly IBandService _bandService;

    public BandController(IBandService bandService)
    {
        _bandService = bandService;
    }    

    [HttpGet]        
    [Route("v1/search")]
    [ProducesResponseType(typeof(BandsViewModel), 200)]        
    public async Task<IActionResult> Get([FromQuery]int pageSize, [FromQuery] string startsWith)
    {
        var result = await _bandService.GetBandsByCriterias(new BandSearchParams(pageSize, startsWith));

        return Ok(result);
    }

    [HttpPost]
    [Authorize(Policy = "admin")]
    [Route("v1/create")]
    public async Task<IActionResult> Post([FromBody]CreateBandModel model)
    {
        await _bandService.CreateBand(model);

        return Ok();
    }

    [HttpPut]
    [Authorize(Policy = "admin")]
    [Route("v1/rename")]
    public async Task<IActionResult> Put([FromQuery]int id, [FromBody]string model)
    {
        await _bandService.RenameBand(id, model);

        return Ok();
    }
}
