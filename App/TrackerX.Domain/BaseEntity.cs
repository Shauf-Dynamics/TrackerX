namespace TrackerX.Domain;

public class BaseEntity
{
    public DateTime? CreatedDateTimeUtc { get; set; }

    public DateTime? ModifiedDateTimeUtc { get; set; }

    public int? CreatedByUserId { get; set; }

    public int? ModifiedByUserId { get; set; }

    public bool IsDeleted { get; set; }
}
