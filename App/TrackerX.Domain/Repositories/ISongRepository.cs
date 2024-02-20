using TrackerX.Domain.Entities;
using TrackerX.Domain.Infrastructure;

namespace TrackerX.Domain.Repositories;

public interface ISongRepository : IRepository<Song>
{
    Task<IEnumerable<Song>> GetByBandIdAsync(int bandId);

    Task<IEnumerable<Song>> SearchAsync(string pattern, string searchBy = "name", bool searchPublic = true);

    Task<IEnumerable<Song>> SearchBySongNameAsync(string startsWith);
}
