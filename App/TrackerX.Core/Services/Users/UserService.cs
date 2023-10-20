using TrackerX.Core.Services.Users.Model;
using TrackerX.Domain.Repositories;

namespace TrackerX.Core.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<AuthorizedUserDto> GetAuthorizedUser(string login, string password)
        {
            var user = await _userRepository.GetUserByCredentials(login, password);

            return user != null ? new AuthorizedUserDto(user.Name, user.RoleType.RoleTypeName) : null;            
        }
    }
}
