using Microsoft.Extensions.DependencyInjection;
using TrackerX.Services.Music;
using TrackerX.Services.Musics;

namespace TrackerX.Service.Musics.Infrastructure
{
    public static class ServicesCollectionExtension
    {
        public static void AddMusicServices(this IServiceCollection services)
        {
            services.AddScoped<IMusicService, MusicService>();
            services.AddScoped<IMusicSearchService, MusicSearchService>();

            services.AddAutoMapper(typeof(MusicMapper));
        }
    }
}
