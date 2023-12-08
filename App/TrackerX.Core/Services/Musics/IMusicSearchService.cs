using TrackerX.Core.Services.Musics.Models;

namespace TrackerX.Core.Services.Music
{
    public interface IMusicSearchService
    {
        Task<SongDetailsView> GetMusicById(int musicId);  

        Task<IEnumerable<SongSearchView>> GetMusicListBySearchCriterias(string text, string searchBy);
    }
}
