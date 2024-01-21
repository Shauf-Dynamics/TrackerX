using Microsoft.Extensions.DependencyInjection;
using TrackerX.Services.Accounts.Invitations;
using TrackerX.Services.Accounts.Users;

namespace TrackerX.Service.Accounts.Infrastructure;

public static class ServicesCollectionExtension
{
    public static void AddAccountServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IInvitationService, InvitationService>();

        services.AddAutoMapper(typeof(AccountMapper));
    }
}
