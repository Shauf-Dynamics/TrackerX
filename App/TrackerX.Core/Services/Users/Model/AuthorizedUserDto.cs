namespace TrackerX.Core.Services.Users.Model
{
    public class AuthorizedUserDto
    {
        public string UserName { get; set; }

        public string UserRole { get; set; }

        public AuthorizedUserDto(string userName, string userRole)
        {
            UserName = userName;
            UserRole = userRole;
        }
    }
}
