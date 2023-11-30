using AutoMapper;
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

        public async Task<ServiceResult<AuthorizedUserDto>> GetAuthorizedUserAsync(string login, string password)
        {            
            var user = await _userRepository.GetUserByCredentialsAsync(login);
            if (user == null)
                return new ServiceResult<AuthorizedUserDto>(StatusType.Failure, "User is not found");

            if (!_passwordHashProvider.Verify(password, user.PasswordHash))           
                return new ServiceResult<AuthorizedUserDto>(StatusType.Failure, "Password is not correct");

            var result = new AuthorizedUserDto(user.Name, user.RoleType.RoleTypeName);

            return new ServiceResult<AuthorizedUserDto>(result, StatusType.Success);
        }

        public async Task<ServiceResult> RegistrateViaInvitationAsync(CreateInvitedUserModel model)
        {
            var invitationResult = await _invitationService.GetValidInvitationCodeAsync(model.InvitationCode);
            if (invitationResult.Status != StatusType.Success)
                return invitationResult.CastToNonGeneric();

            await CreateUser(model);
            var user = await _userRepository.FirstOrDefaultAsync(x => x.Name == model.Name);
            if (user == null)
                return new ServiceResult(StatusType.Failure, "User was not created");

            await _invitationService.AcceptInvitationAsync(invitationResult.Result.InvitationId, user.UserId);

            return new ServiceResult(StatusType.Success);
        }

        private async Task CreateUser(CreateUserModel model)
        {
            // TODO fix magic number
            int clientRoleId = 3;

            var user = _mapper.Map<User>(model);

            user.PasswordHash = _passwordHashProvider.Hash(model.Password);
            user.RoleTypeId = clientRoleId;
            user.RegistrationDttmUtc = DateTime.UtcNow;

             _userRepository.Create(user);
            await _userRepository.SaveChangesAsync();
        }        
    }
}
