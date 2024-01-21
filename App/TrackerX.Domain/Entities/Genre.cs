namespace TrackerX.Domain.Entities;

public sealed class Genre : BaseEntity
{
    public int GenreId { get; set; }

    public string GenreName { get; set; }

    public int? ParentGenreId { get; set; }

    public Genre ParentGenre { get; set; }

    public ICollection<Genre> Subgenres { get; set; }
}
