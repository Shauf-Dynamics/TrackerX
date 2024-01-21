namespace TrackerX.Services.Musics.Models;

public class GenresResult
{
    public int GenreId { get; set; }

    public int? ParentGenreId { get; set; }

    public string GenreName { get; set; }
}
