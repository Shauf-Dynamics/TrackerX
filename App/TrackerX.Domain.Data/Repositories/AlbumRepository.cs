using Microsoft.EntityFrameworkCore;
using TrackerX.Domain.Entities;
using TrackerX.Domain.Infrastructure;
using TrackerX.Domain.Repositories;

namespace TrackerX.Domain.Data.Repositories;

public class AlbumRepository : RepositoryBase<Album>, IAlbumRepository
{
    public AlbumRepository(DataContext context) : base(context) { }

    public async Task<IEnumerable<Album>> GetByBandIdAsync(int bandId)
    {
        IQueryable<Album> query = Context.Albums.Include(x => x.Band);

        return await query.Where(b => b.BandId == bandId).ToListAsync();
    }

    public async Task<IEnumerable<Album>> GetBySearchingCriteriasAsync(int pageSize, string startsWith)
    {
        IQueryable<Album> query = Context.Albums;
        if (!string.IsNullOrWhiteSpace(startsWith))
        {
            query = query.Where(x => x.AlbumName.StartsWith(startsWith));
        }

        return await query.Take(pageSize).ToListAsync();
    }
}
