using System.ComponentModel.DataAnnotations;

namespace TrackerX.Service.Musics.Models;

public class CreateCustomMusicModel
{
    [Required]
    public required string Description { get; set; }

    [Required]
    public required string Author { get; set; }

    [Required]
    public int GenreId { get; set; }

    [Required]
    public int Tempo { get; set; }

    [Required]
    public bool IsInstrumental { get; set; } = false;
}
