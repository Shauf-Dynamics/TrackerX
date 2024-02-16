using Microsoft.Extensions.DependencyInjection;
using TrackerX.Service.Musics.Implementation;
using TrackerX.Services.Musics;

namespace TrackerX.Service.Musics.Infrastructure;

public static class ServicesCollectionExtension
{
    public static void AddMusicServices(this IServiceCollection services)
    {
        services.AddScoped<ISongService, SongService>();
        services.AddScoped<ISongSearchService, SongSearchService>();
        services.AddScoped<ICustomMusicService, CustomMusicService>();
        services.AddScoped<IGenreService, GenreService>();
        services.AddScoped<IMusicProfileService, MusicProfileService>();

        services.AddAutoMapper(typeof(MusicMapper));
    }
}
