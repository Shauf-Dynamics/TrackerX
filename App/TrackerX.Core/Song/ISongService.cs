using TrackerX.Core.Song.Models;

namespace TrackerX.Core.Song
{
    public interface ISongService
    {
        Task Create(CreateSongModel model);

        Task RenameSong(int songId, string songName);

        Task<IEnumerable<SongViewModel>> GetSongsByBandId(int bandId);
    }
}
