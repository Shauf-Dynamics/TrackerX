using TrackerX.Core.Services.Songs.Models;

namespace TrackerX.Core.Services.Songs
{
    public interface ISongService
    {
        Task Create(CreateSongModel model);

        Task RenameSong(int songId, string songName);

        Task AssingToAlbum(int albumId, int songId);

        Task<IEnumerable<SongViewModel>> GetSongsByBandId(int bandId);
    }
}
