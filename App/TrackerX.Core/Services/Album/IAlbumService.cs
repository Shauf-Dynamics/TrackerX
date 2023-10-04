using TrackerX.Core.Services.Album.Models;

namespace TrackerX.Core.Services.Album
{
    public interface IAlbumService
    {
        Task Create(CreateAlbumModel model);        

        Task<AlbumViewModel> GetAlbumById(int id);
    }
}
