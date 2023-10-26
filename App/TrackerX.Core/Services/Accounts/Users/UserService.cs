using AutoMapper;
using TrackerX.Core.Cryptography;
using TrackerX.Core.Infrastructure;
using TrackerX.Core.Services.Accounts.Invitations;
using TrackerX.Core.Services.Accounts.Users.Model;
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

        public UserService(IUserRepository userRepository, IInvitationService invitationService, IPasswordHashProvider passwordHashProvider, IMapper mapper)
        {
            _userRepository = userRepository;
            _invitationService = invitationService;
            _passwordHashProvider = passwordHashProvider;
            _mapper = mapper;
        }

        public async Task<AuthorizedUserDto> GetAuthorizedUser(string login, string password)
        {
            var user = await _userRepository.GetUserByCredentials(login, password);

            return user != null ? new AuthorizedUserDto(user.Name, user.RoleType.RoleTypeName) : null;            
        }

        public async Task Registrate(CreateUserModel model)
        {
            await CreateUser(model);
        }

        public async Task<ServiceResult> RegistrateViaInvitation(CreateUserModel model, string invitationCode)
        {
            var invitation = await _invitationService.GetInvitationByCode(invitationCode);

            if (invitation == null)            
                return new ServiceResult(ResultType.Failure, "Invitation with this code does not exist");

            if (invitation.IsInvitationAborted)
                return new ServiceResult(ResultType.Failure, "Invitation is no longer valid");

            if (invitation.ValideDueDate > DateTime.UtcNow)
                return new ServiceResult(ResultType.Failure, "Invitation was expired");

            if (invitation.UserName != null)
                return new ServiceResult(ResultType.Failure, "Invitation has already been used");

            await CreateUser(model);

            return new ServiceResult(ResultType.Success);
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
