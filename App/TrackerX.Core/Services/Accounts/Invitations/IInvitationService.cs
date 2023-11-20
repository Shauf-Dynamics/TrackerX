using TrackerX.Core.Services.Accounts.Invitations.Models;

namespace TrackerX.Core.Services.Accounts.Invitations
{
    public interface IInvitationService
    {
        Task CreateInvitation(string code, DateTime? dueTo);

        Task AbortInvitation(int invitationId);

        Task AcceptInvitation(int invitationId, int userId);

        Task<IEnumerable<InvitationModel>> GetInvitationList(bool includeAccepted, bool includeAborted);

        Task<InvitationModel> GetInvitationByCode(string code);        
    }
}
