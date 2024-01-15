using TrackerX.Services.Accounts.Users.Models;

namespace TrackerX.Services.Accounts.Users.Models
{
    public class CreateInvitedUserModel : CreateUserModel
    {
        public string InvitationCode { get; set; }
    }
}
