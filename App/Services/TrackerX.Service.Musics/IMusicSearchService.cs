using TrackerX.Services.Musics.Models;

namespace TrackerX.Services.Musics;

public interface IMusicSearchService
{
    Task<SongDetailsResult> GetMusicById(int musicId);

    Task<IEnumerable<SongSearchResult>> GetMusicListBySearchCriterias(string text, string searchBy);

    Task<IEnumerable<GenresResult>> GetAllGenres();
}
