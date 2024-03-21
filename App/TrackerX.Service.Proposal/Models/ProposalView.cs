
namespace TrackerX.Service.Proposals.Models;

public record ProposalView
{
    public required int ProposalId { get; set; }

    public required string SongName { get; set; }

    public required string BandName { get; set; }

    public required string AlbumName { get; set; }

    public required string Status { get; set; }

    public string? Message { get; set; }

    public DateTime OpenedDate { get; set; }

    public DateTime UpdatedDate { get; set; }
}
