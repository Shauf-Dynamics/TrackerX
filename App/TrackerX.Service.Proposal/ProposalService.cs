using TrackerX.Domain.Entities;
using TrackerX.Domain.Repositories;
using TrackerX.Service.Proposals.Models;

namespace TrackerX.Service.Proposals;

public sealed class ProposalService : IProposalService
{
    private readonly IProposalRepository _proposalRepository;

    public ProposalService(IProposalRepository proposalRepository)
    {
        _proposalRepository = proposalRepository;
    }

    public async Task OpenProposalAsync(OpenProposalModel model)
    {
        int proposalStatusOpened = 1;

        var proposal = new Proposal()
        {
            AssetId = model.AssetId,
            AssetType = model.AssetType,
            ProposalAssigneeId = model.UserId,
            ProposalStatusId = proposalStatusOpened
        };

        _proposalRepository.Create(proposal);

        await _proposalRepository.SaveChangesAsync();
    }
}
