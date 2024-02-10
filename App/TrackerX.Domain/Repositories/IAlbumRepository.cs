using TrackerX.Domain.Entities;
using TrackerX.Domain.Infrastructure;

namespace TrackerX.Domain.Repositories;

public interface IAlbumRepository : IRepository<Album>
{
    Task<IEnumerable<Album>> GetBySearchingCriteriasAsync(int pageSize, string startsWith);
    
    Task<IEnumerable<Album>> GetByBandIdAsync(int bandId);
}
