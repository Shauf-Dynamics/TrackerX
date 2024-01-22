using TrackerX.Web.Moduls;
using TrackerX.Cryptography;

var builder = WebApplication.CreateBuilder(args);

var appConfigurationsConnectionString = builder.Configuration.GetValue<string>("ConnectionString__App");
if (!string.IsNullOrWhiteSpace(appConfigurationsConnectionString))
{
    builder.Configuration.AddAzureAppConfiguration(options =>
    {
        options.Connect(appConfigurationsConnectionString);
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
