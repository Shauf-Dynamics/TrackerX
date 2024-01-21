namespace TrackerX.Domain.Entities;

public sealed class TempoType : BaseEntity
{
    public int TempoTypeId { get; set; }

    public string TempoTypeCode { get; set; }

    public string TempoTypeName { get; set; }        
}
