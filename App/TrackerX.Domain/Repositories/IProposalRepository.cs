using TrackerX.Domain.Entities;
using TrackerX.Domain.Infrastructure;

namespace TrackerX.Domain.Repositories;
public interface IProposalRepository : IRepository<Proposal>
{
    Task<IEnumerable<Proposal>> SearchAsync(int userId, string? status);
}
