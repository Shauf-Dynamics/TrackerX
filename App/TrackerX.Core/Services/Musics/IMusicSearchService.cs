using TrackerX.Core.Services.Musics.Models;

namespace TrackerX.Core.Services.Music
{
    public interface IMusicSearchService
    {
        Task<MusicDetailsView> GetMusicById(int musicId);  

        Task<IEnumerable<MusicSearchView>> GetMusicListBySearchCriterias(string text, string searchBy);
    }
}
