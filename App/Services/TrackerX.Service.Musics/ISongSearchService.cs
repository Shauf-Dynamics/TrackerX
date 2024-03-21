using TrackerX.Services.Musics.Models;

namespace TrackerX.Services.Musics;

public interface ISongSearchService
{
    Task<SongDetailsResult> GetSongByIdAsync(int musicId);

    Task<IEnumerable<SongSearchResult>> SearchSongsAsync(string text, string searchBy);
}
