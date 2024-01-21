using Microsoft.Extensions.DependencyInjection;
using TrackerX.Services.Lessons;

namespace TrackerX.Service.Lessons.Infrastructure;

public static class ServicesCollectionExtension
{
    public static void AddLessonServices(this IServiceCollection services)
    {
        services.AddScoped<ILessonService, LessonService>();

        services.AddAutoMapper(typeof(LessonMapper));
    }
}
