using TrackerX.Web.Moduls;
using TrackerX.Cryptography;

namespace TrackerX.Web
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
            _builder.Services.AddCustomCors(allowSpecificOrigins);

            _builder.Services.AddCryptographyServices();
            _builder.Services.AddBusinessServices();

            _builder.Services.AddControllers();
            _builder.Services.AddEndpointsApiExplorer();
            _builder.Services.AddSwaggerGen();

            _builder.Services.AddAuth();

            _builder.Services.AddDataAccess(_builder.Configuration.GetConnectionString("dev"));

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
            app.MapControllers();

            app.Run();
        }
    }
}
