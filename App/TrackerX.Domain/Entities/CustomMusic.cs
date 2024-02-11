namespace TrackerX.Domain.Entities;

public sealed class CustomMusic : BaseEntity
{
    public int CustomMusicId { get; set; }

    public string CustomMusicDescription { get; set; }

    public string AuthorName { get; set; }

    public bool IsOwn { get; set; }

    public bool IsInstrumental { get; set; }

    public int GenreId { get; set; }

    public Genre Genre { get; set; }

    public int Tempo { get; set; }

    public int Year { get; set; }
}
