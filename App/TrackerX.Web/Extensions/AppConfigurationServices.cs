using Azure.Identity;
using TrackerX.UserAccessor;
using TrackerX.Web.Accessors;

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

    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddTransient<IApplicationUserAccessor, ApplicationUserAccessor>();
    }
}
