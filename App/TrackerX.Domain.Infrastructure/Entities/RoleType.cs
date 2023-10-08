namespace TrackerX.Domain.Entities
{
    public class RoleType : BaseEntity
    {
        public int RoleTypeId { get; set; }

        public string RoleTypeCode { get; set; }

        public string RoleTypeName { get; set; }
    }
}
