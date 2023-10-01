using TrackerX.Domain.Infrastructure;

namespace TrackerX.Domain.Entities.Repositories
{
    public interface IBandRepository : IRepository<Band>
    {
        Task<IEnumerable<Band>> GetBySearchingCriterias(int pageSize, string startsWith);
    }
}
