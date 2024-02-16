namespace TrackerX.Service.Musics.Models;

public record MusicProfilesSearchModel
{
    public required int UserId { get; set; }

    public required string DescriptionPattern { get; set; }

    public string Type { get; set; } = "Both";

    public bool? IsPublished { get; set; }
}
