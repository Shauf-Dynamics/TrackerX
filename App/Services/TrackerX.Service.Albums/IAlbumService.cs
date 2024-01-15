using TrackerX.Core.Services.Albums.Models;

namespace TrackerX.Core.Services.Albums
{
    public interface IAlbumService
    {
        Task Create(CreateAlbumModel model);        

        Task<AlbumViewModel> GetAlbumById(int id);
    }
}
