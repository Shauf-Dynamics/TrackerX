using TrackerX.Core.Infrastructure;
using TrackerX.Core.Services.Accounts.Users.Model;

namespace TrackerX.Core.Services.Accounts.Users
{
    public interface IUserService
    {
        Task<AuthorizedUserDto> GetAuthorizedUser(string login, string password);

        Task Registrate(CreateUserModel model);

        Task<ServiceResult> RegistrateViaInvitation(CreateUserModel model, string invitationCode);
    }
}
