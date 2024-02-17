using System.Text.Json.Serialization;

namespace TrackerX.Service.Musics.Models;

public record MusicProfileSearchModel
{
    public string? DescriptionPattern { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public MusicProfileTypeEnum Type { get; set; }

    public bool? IncludePublished { get; set; }
}
