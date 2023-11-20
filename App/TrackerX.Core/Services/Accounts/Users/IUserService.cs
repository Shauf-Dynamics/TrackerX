using TrackerX.Core.Infrastructure;
using TrackerX.Core.Services.Accounts.Users.Models;

namespace TrackerX.Core.Services.Accounts.Users
{
    public interface IUserService
    {
        Task<ServiceResult<AuthorizedUserDto>> GetAuthorizedUserAsync(string login, string password);

        Task<ServiceResult> RegistrateViaInvitationAsync(CreateInvitedUserModel model);
    }
}
