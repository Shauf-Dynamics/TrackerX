using TrackerX.Domain.Entities;
using TrackerX.Domain.Infrastructure;

namespace TrackerX.Domain.Repositories;

public interface IInvitationRepository : IRepository<Invitation>
{
    Task<IEnumerable<Invitation>> GetAllInvitationsAsync(bool includeAccepted, bool includeAborted);
}
