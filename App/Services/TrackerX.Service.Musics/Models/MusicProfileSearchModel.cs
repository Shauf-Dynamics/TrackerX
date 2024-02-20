using System.Text.Json.Serialization;

namespace TrackerX.Service.Musics.Models;

public record MusicProfileSearchModel
{
    public string? DescriptionPattern { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public MusicProfileTypeEnum Type { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public MusicProfilePublicityEnum Publicity { get; set; }
}

public enum MusicProfileTypeEnum
{
    All,
    Song,
    Custom
}

public enum MusicProfilePublicityEnum
{
    All,
    Public,
    Private
}