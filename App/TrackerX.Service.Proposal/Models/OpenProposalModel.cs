namespace TrackerX.Service.Proposals.Models;

public record OpenProposalModel
{
    public required int AssetId { get; set; }

    public required int UserId { get; set; }

    public required string AssetType { get; set; }
}
