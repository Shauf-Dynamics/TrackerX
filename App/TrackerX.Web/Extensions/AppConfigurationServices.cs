using Azure.Identity;
using TrackerX.UserAccessor;
using TrackerX.Web.Accessors;
using TrackerX.Web.Options;

namespace TrackerX.Web.Extensions;

public static class AppConfigurationServices
{
    public static void AddAzureAppConfiguration(this IConfigurationBuilder configurationBuilder, string appConfigurationString)
    {
        if (!string.IsNullOrWhiteSpace(appConfigurationString))
        {
            configurationBuilder.AddAzureAppConfiguration(options =>
            {
                options.Connect(new Uri(appConfigurationString), new DefaultAzureCredential());
            });
        }
    }

    public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddTransient<IApplicationUserAccessor, ApplicationUserAccessor>();

        services.Configure<AppConfigurationOptions>(configuration.GetSection("AppConfig"));
    }
}
