namespace TrackerX.Service.Proposals.Models;

public record ProposalSearchArgs
{
    public string? SongPattern { get; set; }

    public string? Status { get; set; }
}
