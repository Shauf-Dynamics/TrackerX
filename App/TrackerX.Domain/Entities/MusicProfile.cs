namespace TrackerX.Domain.Entities;

public sealed class MusicProfile : BaseEntity
{
    public int MusicProfileId { get; set; }

    public int InitiatorUserId { get; set; }

    public User? InitiatorUser { get; set; }

    public int AssetId { get; set; }

    public string? TypeName { get; set; }

    public bool IsPublished { get; set; }
}
