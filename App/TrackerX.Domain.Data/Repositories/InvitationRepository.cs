using TrackerX.Domain.Entities;
using TrackerX.Domain.Infrastructure;
using TrackerX.Domain.Repositories;

namespace TrackerX.Domain.Data.Repositories
{
    public class InvitationRepository : RepositoryBase<Invitation>, IInvitationRepository
    {
        public InvitationRepository(DataContext context) : base(context)
        {

        }
    }
}
