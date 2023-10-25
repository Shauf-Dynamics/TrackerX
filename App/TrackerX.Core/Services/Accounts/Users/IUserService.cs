using TrackerX.Core.Services.Accounts.Users.Model;

namespace TrackerX.Core.Services.Accounts.Users
{
    public interface IUserService
    {
        Task<AuthorizedUserDto> GetAuthorizedUser(string login, string password);

        Task Register(AddUserModel model);
    }
}
