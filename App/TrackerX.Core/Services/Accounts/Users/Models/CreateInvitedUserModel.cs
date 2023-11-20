using TrackerX.Core.Services.Accounts.Users.Models;

namespace TrackerX.Core.Services.Accounts.Users.Models
{
    public class CreateInvitedUserModel : CreateUserModel
    {
        public string InvitationCode { get; set; }
    }
}
