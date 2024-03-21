using Microsoft.EntityFrameworkCore;
using TrackerX.Domain.Entities;
using TrackerX.Domain.Infrastructure;
using TrackerX.Domain.Repositories;

namespace TrackerX.Domain.Data.Repositories;

public class ProposalRepository : RepositoryBase<Proposal>, IProposalRepository
{
    public ProposalRepository(DataContext context) : base(context) { }

    public async Task<IEnumerable<Proposal>> SearchAsync(int userId, string? status)
    {
        var proposals = Context.Proposals
            .Where(x => x.ProposalAssigneeId == userId)
            .Include(x => x.ProposalStatus)
            .AsQueryable();
        
        if (status != "All")
        {
            proposals = proposals.Where(x => x.ProposalStatus.ProposalStatusName == status);
        }

        return await proposals.ToListAsync();
    }
}
