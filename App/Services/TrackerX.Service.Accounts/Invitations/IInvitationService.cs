using TrackerX.Infrastructure;
using TrackerX.Services.Accounts.Invitations.Models;
using TrackerX.Services.Infrastructure;

namespace TrackerX.Services.Accounts.Invitations;

public interface IInvitationService
{
    Task CreateInvitationAsync(string code, DateTime? dueTo);

    Task AbortInvitationAsync(int invitationId);

    Task AcceptInvitationAsync(int invitationId, int userId);

    Task<IEnumerable<InvitationModel>> GetInvitationListAsync(bool includeAccepted, bool includeAborted);

    Task<InvitationModel> GetInvitationByCodeAsync(string code);        

    Task<ServiceResult<InvitationModel>> GetValidInvitationCodeAsync(string code);
}
