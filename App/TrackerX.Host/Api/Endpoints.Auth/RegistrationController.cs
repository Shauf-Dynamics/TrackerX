using Microsoft.AspNetCore.Mvc;
using TrackerX.Core.Infrastructure;
using TrackerX.Core.Services.Accounts.Users;
using TrackerX.Core.Services.Accounts.Users.Model;
using TrackerX.Core.Services.Accounts.Users.Models;

namespace TrackerX.Host.Api.Gateway.Account
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
            var result = await _userService.Registrate(model);

            if (result.Result != ResultType.Success)
            {
                return BadRequest(result.ErrorMessage);
            }

            return Ok();
        }

        [HttpPost]
        [Route("v1/via-link")]
        public async Task<IActionResult> RegistrateViaInvitation([FromBody] CreateInvitedUserModel model)
        {
            var result = await _userService.RegistrateViaInvitation(model);

            if (result.Result != ResultType.Success) 
            {
                return BadRequest(result.ErrorMessage);
            }

            return Ok();
        }
    }
}
