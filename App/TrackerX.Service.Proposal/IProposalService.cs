using TrackerX.Service.Proposals.Models;

namespace TrackerX.Service.Proposals;

public interface IProposalService
{
    Task OpenProposalAsync(OpenProposalModel model);

    Task<IEnumerable<ProposalView>> GetUserProposals(ProposalSearchArgs searchArgs, int userId);
}
