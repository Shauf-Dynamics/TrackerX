namespace TrackerX.Service.Musics.Models;

public record MusicProfileView
{
    public int MusicProfileId { get; set; }

    public required string Description { get; set; }

    public string? Album { get; set; }

    public string? Author { get; set; }

    public required string Type { get; set; }

    public bool IsPublisher { get; set; }

    public DateTime AssetAddedDate { get; set; }
}
