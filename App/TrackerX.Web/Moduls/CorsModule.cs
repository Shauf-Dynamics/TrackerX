namespace TrackerX.Web.Moduls;

public static class CorsCollectionExtension
{
    public static void AddCustomCors(this IServiceCollection services, string corsPolicyName)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(
                name: corsPolicyName,
                policy =>
                {
                    policy.WithOrigins("http://localhost:4200")
                          .AllowAnyHeader()
                          .AllowCredentials();
                });
        });
    }
}
