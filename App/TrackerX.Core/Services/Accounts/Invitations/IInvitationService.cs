using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerX.Core.Services.Accounts.Invitations
{
    public interface IInvitationService
    {
        Task CreateInvitation(string code, DateTime? dueTo);

        Task AbortInvitation(int invitationId);
    }
}
