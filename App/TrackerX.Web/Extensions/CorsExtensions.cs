namespace TrackerX.Web.Moduls;

public static class CorsCollectionExtension
{
    public static void AddCustomCors(this IServiceCollection services, IConfiguration configuration, string corsPolicyName)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(
                name: corsPolicyName,
                policy =>
                {
                    policy.WithOrigins(configuration.GetValue<string>("AppConfig:ClientUrl"))
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
        });
    }
}
