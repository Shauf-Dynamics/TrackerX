using TrackerX.Service.Proposals.Models;

namespace TrackerX.Service.Proposals;

public interface IProposalService
{
    Task OpenProposalAsync(OpenProposalModel model);
}
