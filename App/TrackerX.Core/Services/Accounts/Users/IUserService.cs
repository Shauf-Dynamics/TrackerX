using TrackerX.Core.Infrastructure;
using TrackerX.Core.Services.Accounts.Users.Models;

namespace TrackerX.Core.Services.Accounts.Users
{
    public interface IUserService
    {
        Task<AuthorizedUserDto> GetAuthorizedUser(string login, string password);

        Task<ServiceResult> Registrate(CreateUserModel model);

        Task<ServiceResult> RegistrateViaInvitation(CreateInvitedUserModel model);
    }
}
