using TrackerX.Domain.Entities;
using TrackerX.Domain.Infrastructure;

namespace TrackerX.Domain.Repositories
{
    public interface IMusicRepository : IRepository<Music>
    {
        Task<IEnumerable<Music>> GetByBandIdAsync(int bandId);

        Task<IEnumerable<Music>> GetBySearchCriteriasdAsync(string text, string searchBy);
    }
}
