using Microsoft.EntityFrameworkCore;
using TrackerX.Core.Band;
using TrackerX.Core.Song;
using TrackerX.Domain.Data.Repositories;
using TrackerX.Domain.Entities.Repositories;
using TrackerX.Domain.Infrastructure;
using TrackerX.Domain.Repositories;

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

builder.Services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
builder.Services.AddTransient<IBandRepository, BandRepository>();
builder.Services.AddTransient<ISongRepository, SongRepository>();

builder.Services.AddScoped<IBandService, BandService>();
builder.Services.AddScoped<ISongService, SongService>();
/*builder.Services.AddScoped<IRecordListService, RecordListService>();
builder.Services.AddScoped<IRecordService, RecordService>();
builder.Services.AddScoped<IDashboardService, DashboardService>();*/

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
