using TrackerX.Web.Moduls;
using TrackerX.Cryptography;
using Azure.Identity;

var builder = WebApplication.CreateBuilder(args);

var appConfigurationsConnectionString = builder.Configuration.GetConnectionString("AppConfig");
if (!string.IsNullOrWhiteSpace(appConfigurationsConnectionString))
{
    builder.Configuration.AddAzureAppConfiguration(options =>
    {
        options.Connect(new Uri(appConfigurationsConnectionString), new DefaultAzureCredential());
    });
}

var allowSpecificOrigins = "_allowSpecificOrigins";
builder.Services.AddCustomCors(builder.Configuration, allowSpecificOrigins);
builder.Services.AddCryptographyServices();
builder.Services.AddBusinessServices();

builder.Services.AddDataAccess(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuth(builder.Configuration);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(allowSpecificOrigins);

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
