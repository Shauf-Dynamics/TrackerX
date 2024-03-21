using Microsoft.Extensions.DependencyInjection;

namespace TrackerX.Service.Proposals.Infrastructure;

public static class ServicesCollectionExtension
{
    public static void AddProposalServices(this IServiceCollection services)
    {
        services.AddScoped<IProposalService, ProposalService>();
    }
}
