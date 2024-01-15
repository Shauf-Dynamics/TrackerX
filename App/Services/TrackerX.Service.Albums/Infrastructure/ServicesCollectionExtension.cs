using Microsoft.Extensions.DependencyInjection;
using TrackerX.Core.Services.Albums;

namespace TrackerX.Service.Albums.Infrastructure
{
    public static class ServicesCollectionExtension
    {
        public static void AddAlbumServices(this IServiceCollection services)
        {
            services.AddScoped<IAlbumService, AlbumService>();

            services.AddAutoMapper(typeof(AlbumMapper));
        }
    }
}
