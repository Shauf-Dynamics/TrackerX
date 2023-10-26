using Microsoft.AspNetCore.Mvc;
using TrackerX.Core.Infrastructure;
using TrackerX.Core.Services.Accounts.Users;
using TrackerX.Core.Services.Accounts.Users.Model;

namespace TrackerX.Host.Api.Gateway.Account
{
    [ApiController]
    [Route("api/account/[controller]")]
    public class RegistrationController : Controller
    {
        private readonly IUserService _userService;

        public RegistrationController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("v1/via-link")]
        public async Task<IActionResult> RegistrateViaInvitation([FromBody] CreateUserModel model, [FromQuery] string invitationCode)
        {
            var result = await _userService.RegistrateViaInvitation(model, invitationCode);

            if (result.Result != ResultType.Success) 
            {
                return BadRequest(result.ErrorMessage);
            }

            return Ok();
        }
    }
}
