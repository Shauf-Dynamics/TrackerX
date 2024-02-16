namespace TrackerX.Domain.Entities;

public sealed class MusicProfile : BaseEntity
{
    public required int MusicProfileId { get; set; }

    public required int CreatorUserId { get; set; }

    public required User CreatorUser { get; set; }

    public required int AssetId { get; set; }

    public required string TypeName { get; set; }

    public required bool IsPublished { get; set; }
}
