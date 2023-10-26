using TrackerX.Domain.Entities;
using TrackerX.Domain.Repositories;

namespace TrackerX.Core.Services.Accounts.Invitations
{
    public class InvitationService : IInvitationService
    {
        private readonly IInvitationRepository _invitationRepository;

        public InvitationService(IInvitationRepository invitationRepository)
        {
            _invitationRepository = invitationRepository;
        }

        public async Task AbortInvitation(int invitationId)
        {
            var invitation = await _invitationRepository.FirstOrDefault(x => x.InvitationId == invitationId);

            if(invitation != null) 
            {
                invitation.IsInvitationAborted = true;

                _invitationRepository.Update(invitation);
                await _invitationRepository.SaveChanges();
            }            
        }

        public async Task CreateInvitation(string code, DateTime? dueTo)
        {
            var invitation = new Invitation();
            invitation.Code = code;
            invitation.ValideDueDate = dueTo;

            _invitationRepository.Create(invitation);
            await _invitationRepository.SaveChanges();
        }
    }
}
