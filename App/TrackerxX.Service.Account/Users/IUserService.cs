using TrackerX.Services.Accounts.Users.Models;
using TrackerX.Services.Infrastructure;

namespace TrackerX.Services.Accounts.Users
{
    public interface IUserService
    {
        Task<ServiceResult<AuthorizedUserDto>> GetAuthorizedUserAsync(string login, string password);

        Task<ServiceResult> RegistrateViaInvitationAsync(CreateInvitedUserModel model);
    }
}
