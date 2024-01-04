﻿using Microsoft.AspNetCore.Mvc;
using TrackerX.Core.Infrastructure;
using TrackerX.Core.Services.Accounts.Users;
using TrackerX.Core.Services.Accounts.Users.Models;

namespace TrackerX.Web.Api.Gateway.Account
{
    [ApiController]
    [Route("api/account/registration")]
    public class RegistrationController : Controller
    {
        private readonly IUserService _userService;

        public RegistrationController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]        
        [Route("v1")]
        public async Task<IActionResult> Registrate([FromBody] CreateUserModel model)
        {
            return BadRequest("Not implemented");
        }

        [HttpPost]
        [Route("v1/via-link")]
        public async Task<IActionResult> RegistrateViaInvitation([FromBody] CreateInvitedUserModel model)
        {
            var result = await _userService.RegistrateViaInvitationAsync(model);

            if (result.Status != StatusType.Success) 
            {
                return BadRequest(result.ErrorMessage);
            }

            return Ok();
        }
    }
}
