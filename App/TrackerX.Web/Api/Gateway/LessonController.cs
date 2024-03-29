﻿using Microsoft.AspNetCore.Mvc;
using TrackerX.Services.Lessons.Models;
using TrackerX.Services.Lessons;
using Microsoft.AspNetCore.Authorization;

namespace TrackerX.Web.Api.Gateway;

[Route("api/[controller]")]
[Authorize(Policy = "admin")]
[ApiController]
public class LessonController : ControllerBase
{
    private readonly ILessonService _lessonService;

    public LessonController(ILessonService lessonService)
    {
        _lessonService = lessonService;
    }

    [HttpPost]
    [Route("v1/create")]
    public async Task<IActionResult> Post([FromBody] CreateLessonModel model)
    {
        await _lessonService.Create(model);

        return Ok();
    }
}
