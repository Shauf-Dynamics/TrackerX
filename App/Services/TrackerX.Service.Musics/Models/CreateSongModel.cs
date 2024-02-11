using System.ComponentModel.DataAnnotations;

namespace TrackerX.Services.Musics.Models;

public record CreateSongModel
{
    [Required]
    public required string SongName { get; set; }    

    [Required]
    public int GenreId { get; set; }

    [Required]
    public int BandId { get; set; }

    [Required]
    public int AlbumId { get; set; }

    [Required]
    public int Tempo { get; set; }

    [Required]
    public bool IsInstrumental { get; set; } = false;

    [Required]
    public bool IsAgreedToPublish { get; set; }
}
