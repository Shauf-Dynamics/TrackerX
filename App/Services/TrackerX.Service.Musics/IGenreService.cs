using TrackerX.Services.Musics.Models;

namespace TrackerX.Service.Musics;

public interface IGenreService
{
    Task<IEnumerable<GenresResult>> GetAllGenresAsync();
}
