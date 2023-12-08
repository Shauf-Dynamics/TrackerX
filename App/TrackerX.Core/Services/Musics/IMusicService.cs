using TrackerX.Core.Services.Musics.Models;

namespace TrackerX.Core.Services.Music
{
    public interface IMusicService
    {
        Task Create(CreateMusicModel model);

        Task RenameSong(int songId, string songName);

        Task AssingToAlbum(int albumId, int songId);
    }
}
