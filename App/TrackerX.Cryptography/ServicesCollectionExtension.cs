using Microsoft.Extensions.DependencyInjection;

namespace TrackerX.Cryptography;

public static class ServicesCollectionExtension
{
    public static void AddCryptographyServices(this IServiceCollection services)
    {
        services.AddTransient<IPasswordHashProvider, PasswordHashProvider>();
    }
}
