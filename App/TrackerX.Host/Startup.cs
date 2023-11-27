using Microsoft.AspNetCore.Authentication.Cookies;
using TrackerX.Core.Mapping;
using TrackerX.Host.Moduls;

namespace TrackerX.Host
{
    public class Startup
    {
        private WebApplicationBuilder _builder { get; }

        public Startup(params string[] args)
        {
            _builder = WebApplication.CreateBuilder(args);
        }

        public void ConfigureAndRun()
        {
            var allowSpecificOrigins = "_allowSpecificOrigins";

            _builder.Services.AddCors(options =>
            {
                options.AddPolicy(
                    name: allowSpecificOrigins,
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:4200")
                              .AllowAnyHeader()
                              .AllowCredentials();
                    });
            });

            _builder.Services.AddControllers();
            _builder.Services.AddEndpointsApiExplorer();
            _builder.Services.AddSwaggerGen();

            _builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
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

            DataAccessModule.Configure(_builder);
            ServiceModule.Configure(_builder);

            _builder.Services.AddAutoMapper(typeof(AppMappingProfile));
            
            var app = _builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(allowSpecificOrigins);

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
