namespace TrackerX.Domain.Entities
{
    public class Account
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Token { get; set; }

        public DateTime RegistrationDttm { get; set; }

        public bool IsDeactivated { get; set; }

        public int RoleId { get; set; }
    }
}
