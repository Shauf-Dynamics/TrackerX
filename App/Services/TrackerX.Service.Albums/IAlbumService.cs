using TrackerX.Core.Services.Albums.Models;
using TrackerX.Service.Albums.Models;

namespace TrackerX.Core.Services.Albums;

public interface IAlbumService
{
    Task CreateAsync(CreateAlbumModel model);

    Task<IEnumerable<AlbumViewModel>> GetAlbumsByCriteriasAsync(AlbumSearchParams searchParams);

    Task<IEnumerable<AlbumViewModel>> GetAlbumsByBandAsync(int bandId);

    Task<AlbumViewModel> GetAlbumByIdAsync(int id);
}
