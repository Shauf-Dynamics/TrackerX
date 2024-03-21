namespace TrackerX.Domain.Entities;

public class Proposal : BaseEntity
{
    public int ProposalId { get; set; }

    public int ProposalStatusId { get; set; }

    public ProposalStatus ProposalStatus { get; set; }

    public int ProposalAssigneeId { get; set; }

    public User ProposalAssignee { get; set; }

    public int AssetId { get; set; }

    public string AssetType { get; set; }

    public string ResponseMessage { get; set; }
}
