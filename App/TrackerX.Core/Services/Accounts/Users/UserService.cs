using AutoMapper;
using TrackerX.Core.Infrastructure.Cryptography;
using TrackerX.Core.Services.Accounts.Users.Model;
using TrackerX.Domain.Entities;
using TrackerX.Domain.Repositories;

namespace TrackerX.Core.Services.Accounts.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHashProvider _passwordHashProvider;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IPasswordHashProvider passwordHashProvider, IMapper mapper)
        {
            _userRepository = userRepository;
            _passwordHashProvider = passwordHashProvider;
            _mapper = mapper;
        }

        public async Task<AuthorizedUserDto> GetAuthorizedUser(string login, string password)
        {
            var user = await _userRepository.GetUserByCredentials(login, password);

            return user != null ? new AuthorizedUserDto(user.Name, user.RoleType.RoleTypeName) : null;            
        }

        public async Task Register(AddUserModel model)
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
