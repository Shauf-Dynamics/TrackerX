namespace TrackerX.Domain.Entities;

public class ProposalStatus : BaseEntity
{
    public int ProposalStatusId { get; set; }

    public string ProposalStatusCode { get; set; }

    public string ProposalStatusName { get; set; }
}
