using TrackerX.Domain.Entities;
using TrackerX.Domain.Infrastructure;
using TrackerX.Domain.Repositories;

namespace TrackerX.Domain.Data.Repositories;

public class ProposalRepository : RepositoryBase<Proposal>, IProposalRepository
{
    public ProposalRepository(DataContext context) : base(context) { }
}
