using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TrackerX.Infrastructure;
using TrackerX.Services.Accounts.Users;
using TrackerX.Services.Accounts.Users.Models;
using TrackerX.Web.Api.Endpoints.Admin.Models;

namespace TrackerX.Web.Api.Gateway.Account
{
    [ApiController]
    [Route("api/account")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _config;

        public AuthenticationController(IUserService userService, IConfiguration config)
        {
            _userService = userService;
            _config = config;
        }

        [HttpGet]
        [Authorize]
        [Route("v1/user")]
        public IActionResult GetUserClaim()
        {
            var name = User.FindFirstValue(ClaimTypes.Name);
            var role = User.FindFirstValue(ClaimTypes.Role);

            return Ok(new { name, role });
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("v1/auth")]
        [ProducesResponseType(typeof(SignedUserView), 200)]
        public async Task<IActionResult> LogIn([FromBody] SignInModel model)
        {
            List<Claim> claims;

            if (IsSuperAdmin(model.Login, model.Password))
            {
                claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, "_sa"),
                    new Claim(ClaimTypes.Role, "Superadmin"),
                };
            }
            else
            {
                var userResult = await _userService.GetAuthorizedUserAsync(model.Login, model.Password);
                if (userResult.Status == StatusType.Failure)
                    return Forbid(userResult.ErrorMessage);

                AuthorizedUserDto user = userResult.Result;
                claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Role, user.UserRole),
                };
            }

            await SignIn(claims);

            return Ok(new SignedUserView()
            {
                UserName = claims.First(x => x.Type == ClaimTypes.Name).Value,
                Role = claims.First(x => x.Type == ClaimTypes.Role).Value
            });
        }

        [HttpGet]
        [Authorize]
        [Route("v1/signout")]
        public async Task LogOut()
        {
            await HttpContext.SignOutAsync();
        }
        
        private async Task SignIn(List<Claim> claims)
        {
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {                
                AllowRefresh = true,
                IsPersistent = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(60),
                IssuedUtc = DateTime.UtcNow
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
        }

        private bool IsSuperAdmin(string name, string password)
        {
            var saLogin = _config["Credentials:SuperadminLogin"];
            var saPassword = _config["Credentials:SuperadminPassword"];

            return name.Equals(saLogin) && password.Equals(saPassword);
        }
    }
}
