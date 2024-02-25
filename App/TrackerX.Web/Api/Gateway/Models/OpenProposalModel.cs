using System.ComponentModel.DataAnnotations;

namespace TrackerX.Web.Api.Gateway.Models;

public record OpenProposalModel
{
    [Required]
    public required int AssetId { get; set; }

    [Required]
    public required string AssetType { get; set; }
}
