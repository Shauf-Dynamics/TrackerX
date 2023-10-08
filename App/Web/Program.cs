using Microsoft.EntityFrameworkCore;
using TrackerX.Core.Infrastructure;
using TrackerX.Core.Services.Albums;
using TrackerX.Core.Services.Bands;
using TrackerX.Core.Services.Lessons;
using TrackerX.Core.Services.Songs;
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

builder.Services.AddScoped(typeof(IRepository<>), typeof(RepositoryBase<>));
builder.Services.AddTransient<IBandRepository, BandRepository>();
builder.Services.AddTransient<ISongRepository, SongRepository>();
builder.Services.AddTransient<IAlbumRepository, AlbumRepository>();
builder.Services.AddTransient<ILessonRepository, LessonRepository>();
builder.Services.AddTransient<IExerciseRepository, ExerciseRepository>();

builder.Services.AddScoped<IBandService, BandService>();
builder.Services.AddScoped<ILessonService, LessonService>();
builder.Services.AddScoped<ISongService, SongService>();
builder.Services.AddScoped<IAlbumService, AlbumService>();

builder.Services.AddAutoMapper(typeof(AppMappingProfile));

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
