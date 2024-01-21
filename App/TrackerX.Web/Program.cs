using TrackerX.Web;
using TrackerX.Web.Moduls;
using TrackerX.Cryptography;

var builder = WebApplication.CreateBuilder(args);

var allowSpecificOrigins = "_allowSpecificOrigins";
builder.Services.AddCustomCors(allowSpecificOrigins);

builder.Services.AddCryptographyServices();
builder.Services.AddBusinessServices();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuth();

builder.Services.AddDataAccess(builder.Configuration.GetConnectionString("dev"));

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
     app.UseSwagger();
     app.UseSwaggerUI();
//}

app.UseCors(allowSpecificOrigins);

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
