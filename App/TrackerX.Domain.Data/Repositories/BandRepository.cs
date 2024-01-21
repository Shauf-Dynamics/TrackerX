using Microsoft.EntityFrameworkCore;
using TrackerX.Domain.Entities;
using TrackerX.Domain.Entities.Repositories;
using TrackerX.Domain.Infrastructure;

namespace TrackerX.Domain.Data.Repositories;

public class BandRepository : RepositoryBase<Band>, IBandRepository
{
    public BandRepository(DataContext context) : base(context) { }

    public async Task<IEnumerable<Band>> GetBySearchingCriteriasAsync(int pageSize, string startsWith)
    {
        IQueryable<Band> query = Context.Bands;
        if (!string.IsNullOrWhiteSpace(startsWith))
        {
            query = query.Where(x => x.BandName.StartsWith(startsWith));
        }

        return await query.Take(pageSize).ToListAsync();
    }
}
