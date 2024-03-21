using TrackerX.Service.Proposals.Models;

namespace TrackerX.Service.Proposals;

public interface IProposalService
{
    Task OpenProposalAsync(OpenProposalModel modeln);

    Task AcceptProposalAsync(int proposalId);

    Task RevokeProposalAsync(int proposalId, int userId);

    Task<IEnumerable<ProposalView>> GetUserProposalsAsync(ProposalSearchArgs searchArgs, int userId);
}
