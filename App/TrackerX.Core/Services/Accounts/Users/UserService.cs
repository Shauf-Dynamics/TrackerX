using AutoMapper;
using System.Reflection;
using TrackerX.Core.Cryptography;
using TrackerX.Core.Infrastructure;
using TrackerX.Core.Services.Accounts.Invitations;
using TrackerX.Core.Services.Accounts.Users.Models;
using TrackerX.Domain.Entities;
using TrackerX.Domain.Repositories;

namespace TrackerX.Core.Services.Accounts.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IInvitationService _invitationService;
        private readonly IPasswordHashProvider _passwordHashProvider;
        private readonly IMapper _mapper;

        public UserService(
            IUserRepository userRepository,
            IInvitationService invitationService, 
            IPasswordHashProvider passwordHashProvider,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _invitationService = invitationService;
            _passwordHashProvider = passwordHashProvider;
            _mapper = mapper;
        }

        public async Task<ServiceResult<AuthorizedUserDto>> GetAuthorizedUser(string login, string password)
        {            
            var user = await _userRepository.GetUserByCredentials(login);
            if (user == null)
                return new ServiceResult<AuthorizedUserDto>(StatusType.Failure, "User is not found");

            var isVerified = _passwordHashProvider.Verify(password, user.PasswordHash);
            if (!isVerified)           
                return new ServiceResult<AuthorizedUserDto>(StatusType.Failure, "Password is not correct");

            var result = new AuthorizedUserDto(user.Name, user.RoleType.RoleTypeName);

            return new ServiceResult<AuthorizedUserDto>(result, StatusType.Success);
        }

        public async Task<ServiceResult> Registrate(CreateUserModel model)
        {
            await CreateUser(model);

            return new ServiceResult(StatusType.Success);
        }

        public async Task<ServiceResult> RegistrateViaInvitation(CreateInvitedUserModel model)
        {
            var invitation = await _invitationService.GetInvitationByCode(model.InvitationCode);

            if (invitation == null)            
                return new ServiceResult(StatusType.Failure, "Invitation with this code does not exist");

            if (invitation.IsInvitationAborted)
                return new ServiceResult(StatusType.Failure, "Invitation is no longer valid");

            if (invitation.ValideDueDate > DateTime.UtcNow)
                return new ServiceResult(StatusType.Failure, "Invitation was expired");

            if (invitation.UserName != null)
                return new ServiceResult(StatusType.Failure, "Invitation has already been used");

            await CreateUser(model);

            var user = await _userRepository.FirstOrDefault(x => x.Name == model.Name);
            if (user == null)
                return new ServiceResult(StatusType.Failure, "User was not created");

            await _invitationService.AcceptInvitation(invitation.InvitationId, user.UserId);

            return new ServiceResult(StatusType.Success);
        }

        private async Task CreateUser(CreateUserModel model)
        {
            int clientRoleId = 3;

            var user = _mapper.Map<User>(model);

            user.PasswordHash = _passwordHashProvider.Hash(model.Password);
            user.RoleTypeId = clientRoleId;
            user.RegistrationDttmUtc = DateTime.UtcNow;

             _userRepository.Create(user);
            await _userRepository.SaveChanges();
        }        
    }
}
