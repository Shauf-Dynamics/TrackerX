namespace TrackerX.Service.Musics.Models;

public record MusicProfileView
{
    public required int MusicProfileId { get; set; }

    public required int MusicId { get; set; }

    public required string Description { get; set; }

    public string? Album { get; set; }

    public string? Author { get; set; }

    public required string Type { get; set; }

    public bool IsPublished { get; set; }

    public DateTime AssetAddedDate { get; set; }
}
