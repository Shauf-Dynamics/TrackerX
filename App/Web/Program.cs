using Domain;
using Microsoft.EntityFrameworkCore;
using Web.Application.Endpoints.RecordList.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#if DEBUG
    var connectionString = builder.Configuration.GetConnectionString("dev");
#else
    var connectionString = builder.Configuration.GetConnectionString("prod");
#endif

builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(connectionString));

builder.Services.AddScoped<IRecordListService, RecordListService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
