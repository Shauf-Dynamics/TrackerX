namespace TrackerX.Domain.Entities
{
    public sealed class Invitation : BaseEntity
    {
        public int InvitationId { get; set; }        

        public string Code { get; set; }

        public DateTime? ValideDueDate { get; set; }

        public bool IsInvitationAborted { get; set; }

        public int? UserId { get; set; }

        public User User { get; set; }
    }
}
