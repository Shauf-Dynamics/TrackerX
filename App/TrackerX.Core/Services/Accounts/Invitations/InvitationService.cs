using AutoMapper;
using TrackerX.Core.Infrastructure;
using TrackerX.Core.Services.Accounts.Invitations.Models;
using TrackerX.Domain.Entities;
using TrackerX.Domain.Repositories;

namespace TrackerX.Core.Services.Accounts.Invitations
{
    public class InvitationService : IInvitationService
    {
        private readonly IInvitationRepository _invitationRepository;
        private readonly IMapper _mapper;

        public InvitationService(IInvitationRepository invitationRepository, IMapper mapper)
        {
            _invitationRepository = invitationRepository;
            _mapper = mapper;
        }

        public async Task AbortInvitationAsync(int invitationId)
        {
            var invitation = await _invitationRepository.FirstOrDefaultAsync(x => x.InvitationId == invitationId);

            if(invitation != null) 
            {
                invitation.IsInvitationAborted = true;

                _invitationRepository.Update(invitation);
                await _invitationRepository.SaveChangesAsync();
            }            
        }

        public async Task AcceptInvitationAsync(int invitationId, int userId)
        {
            var invitation = await _invitationRepository.FirstOrDefaultAsync(x => x.InvitationId == invitationId);

            invitation.UserId = userId;
            invitation.AcceptedDate = DateTime.UtcNow;

            _invitationRepository.Update(invitation);
            await _invitationRepository.SaveChangesAsync();
        }

        public async Task CreateInvitationAsync(string code, DateTime? dueTo)
        {
            var invitation = new Invitation();
            invitation.Code = code;
            invitation.ValideDueDate = dueTo;

            _invitationRepository.Create(invitation);
            await _invitationRepository.SaveChangesAsync();
        }

        public async Task<InvitationModel> GetInvitationByCodeAsync(string code)
        {
            var invitation = await _invitationRepository.FirstOrDefaultAsync(x => x.Code == code);

            return _mapper.Map<InvitationModel>(invitation);
        }

        public async Task<IEnumerable<InvitationModel>> GetInvitationListAsync(bool includeAccepted, bool includeAborted)
        {
            var invitations = await _invitationRepository.GetAllInvitationsAsync(includeAccepted, includeAborted);

            return _mapper.Map<IEnumerable<InvitationModel>>(invitations);            
        }

        public async Task<ServiceResult<InvitationModel>> GetValidInvitationCodeAsync(string code)
        {
            var invitation = await _invitationRepository.FirstOrDefaultAsync(x => x.Code == code);

            if (invitation == null)
                return new ServiceResult<InvitationModel>(StatusType.Failure, "Invitation with this code does not exist");

            if (invitation.IsInvitationAborted)
                return new ServiceResult<InvitationModel>(StatusType.Failure, "Invitation is no longer valid");

            if (invitation.ValideDueDate > DateTime.UtcNow)
                return new ServiceResult<InvitationModel>(StatusType.Failure, "Invitation was expired");

            if (invitation.UserId != null)
                return new ServiceResult<InvitationModel>(StatusType.Failure, "Invitation has already been used");

            return new ServiceResult<InvitationModel>(_mapper.Map<InvitationModel>(invitation), StatusType.Success);            
        }
    }
}
