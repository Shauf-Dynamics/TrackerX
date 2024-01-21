namespace TrackerX.Domain.Entities;

public sealed class Music : BaseEntity
{
    public int MusicId { get; set; }

    public string MusicDescription { get; set; }

    public string AuthorName { get; set; }

    public bool IsOwn { get; set; }

    public bool IsInstrumental { get; set; }

    public int GenreId { get; set; }

    public Genre Genre { get; set; }

    public int Tempo { get; set; }

    public int Year { get; set; }
}
