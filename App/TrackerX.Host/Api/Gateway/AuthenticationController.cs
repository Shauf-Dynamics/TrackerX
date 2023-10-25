﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TrackerX.Core.Services.Accounts.Users;

namespace TrackerX.Host.Api.Gateway
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _config;        

        public AuthenticationController(IUserService userService, IConfiguration config)
        {
            _userService = userService;
            _config = config;
        }

        [HttpPost]
        [Route("v1/auth")]
        public async Task<IActionResult> OnPostAsync(string login, string password)
        {
            List<Claim> claims;

            if (IsSuperAdmin(login, password))
            {
                claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, "_sa"),
                    new Claim(ClaimTypes.Role, "Superadmin"),
                };
            }
            else
            {
                var userDto = await _userService.GetAuthorizedUser(login, password);

                if (userDto != null)
                {
                    claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, userDto.UserName),
                        new Claim(ClaimTypes.Role, userDto.UserRole),
                    };
                }
                else
                {
                    return Forbid();
                }
            }

            await SignIn(claims);

            return Ok();
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
            var saLogin = _config["Credentials: SuperadminLogin"];
            var saPassword = _config["Credentials: SuperadminPassword"];

            return name.Equals(saLogin) && password.Equals(saPassword);            
        }
    }
}