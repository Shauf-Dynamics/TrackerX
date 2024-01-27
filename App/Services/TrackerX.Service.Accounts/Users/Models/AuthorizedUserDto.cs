namespace TrackerX.Services.Accounts.Users.Models;

public class AuthorizedUserDto
{
    public int UserId{ get; set; }

    public string UserName { get; set; }

    public string UserRole { get; set; }

    public AuthorizedUserDto(int userId, string userName, string userRole)
    {
        UserId = userId;
        UserName = userName;
        UserRole = userRole;
    }
}
