using Microsoft.EntityFrameworkCore;
using TrackerX.Domain.Entities;
using TrackerX.Domain.Infrastructure;
using TrackerX.Domain.Repositories;

namespace TrackerX.Domain.Data.Repositories
{
    public class InvitationRepository : RepositoryBase<Invitation>, IInvitationRepository
    {
        public InvitationRepository(DataContext context) : base(context) { }

        public async Task<IEnumerable<Invitation>> GetAllInvitationsAsync(bool includeAccepted, bool includeAborted)
        {
            IQueryable<Invitation> invitations = Context.Invitations;

            if (!includeAborted)
            {
                invitations = invitations.Where(x => !x.IsInvitationAborted);
            }

            if (!includeAccepted)
            {
                invitations = invitations.Where(x => x.UserId == null);
            }

            return await invitations
                .Include(x => x.User)
                .ToListAsync();
        }
    }
}
