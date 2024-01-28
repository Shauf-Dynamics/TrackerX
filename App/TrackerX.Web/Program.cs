using TrackerX.Web.Moduls;
using TrackerX.Cryptography;
using TrackerX.Domain.Data;
using TrackerX.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddAzureAppConfiguration(builder.Configuration.GetConnectionString("AppConfig:ConnectionString"));

var allowSpecificOrigins = "_allowSpecificOrigins";
builder.Services.AddCustomCors(builder.Configuration, allowSpecificOrigins);
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddCryptographyServices();
builder.Services.AddBusinessServices();

builder.Services.AddDataServices(builder.Configuration);

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
