using TrackerX.Core.Services.Accounts.Users.Model;

namespace TrackerX.Core.Services.Accounts.Users.Models
{
    public class CreateInvitedUserModel : CreateUserModel
    {
        public string InvitationCode { get; set; }
    }
}
