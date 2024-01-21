using Microsoft.Extensions.DependencyInjection;
using TrackerX.Services.Bands;

namespace TrackerX.Service.Bands.Infrastructure;

public static class ServicesCollectionExtension
{
    public static void AddBandServices(this IServiceCollection services)
    {
        services.AddScoped<IBandService, BandService>();

        services.AddAutoMapper(typeof(BandMapper));
    }
}
