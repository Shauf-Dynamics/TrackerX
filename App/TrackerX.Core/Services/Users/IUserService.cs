using TrackerX.Core.Services.Users.Model;

namespace TrackerX.Core.Services.Users
{
    public interface IUserService
    {
        Task<AuthorizedUserDto> GetAuthorizedUser(string login, string password);
    }
}
