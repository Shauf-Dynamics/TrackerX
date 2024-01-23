using Microsoft.AspNetCore.Authentication.Cookies;
using TrackerX.Web.Configurations;

namespace TrackerX.Web.Moduls;

public static class AuthCollectionExtension
{
    public static void AddAuth(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<SuperAdminOptions>(configuration.GetSection("Credentials:Superadmin"));

        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.Cookie.SameSite = SameSiteMode.None;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                options.SlidingExpiration = true;
                options.Events.OnRedirectToAccessDenied =
                options.Events.OnRedirectToLogin = c =>
                {
                    c.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    return Task.FromResult<object>(null);
                };
            });
    }
}
