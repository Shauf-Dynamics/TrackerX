using TrackerX.Domain.Entities;
using TrackerX.Domain.Infrastructure;

namespace TrackerX.Domain.Repositories;

public interface ISongRepository : IRepository<Song>
{
    Task<IEnumerable<Song>> GetByBandIdAsync(int bandId);

    Task<IEnumerable<Song>> GetBySearchCriteriasAsync(string text, string searchBy);
}
