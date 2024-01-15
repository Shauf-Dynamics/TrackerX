using TrackerX.Services.Musics.Models;

namespace TrackerX.Services.Music
{
    public interface IMusicService
    {
        Task Create(CreateMusicModel model);

        Task RenameSong(int songId, string songName);

        Task AssingToAlbum(int albumId, int songId);
    }
}
