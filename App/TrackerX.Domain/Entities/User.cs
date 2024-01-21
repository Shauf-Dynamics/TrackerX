namespace TrackerX.Domain.Entities;

public class User : BaseEntity
{
    public int UserId { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public string PasswordHash { get; set; }

    public DateTime RegistrationDttmUtc { get; set; }

    public int RoleTypeId { get; set; }

    public RoleType RoleType { get; set; }
}
