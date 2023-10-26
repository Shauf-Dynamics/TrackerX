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
            _builder.Services.AddControllers();
            _builder.Services.AddEndpointsApiExplorer();
            _builder.Services.AddSwaggerGen();

            _builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
                    options.SlidingExpiration = true;
                    options.AccessDeniedPath = "/Forbidden/";
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
