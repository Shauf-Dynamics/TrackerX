using TrackerX.Core.Services.Musics.Models;

namespace TrackerX.Core.Services.Music
{
    public interface IMusicSearchService
    {
        Task<SongDetailsResult> GetMusicById(int musicId);  

        Task<IEnumerable<SongSearchResult>> GetMusicListBySearchCriterias(string text, string searchBy);

        Task<IEnumerable<GenresResult>> GetAllGenres();
    }
}
