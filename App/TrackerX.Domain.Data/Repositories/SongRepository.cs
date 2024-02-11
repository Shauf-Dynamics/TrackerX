using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TrackerX.Domain.Entities;
using TrackerX.Domain.Infrastructure;
using TrackerX.Domain.Repositories;

namespace TrackerX.Domain.Data.Repositories;

public class SongRepository : RepositoryBase<Song>, ISongRepository 
{
    private const int defaultAmountToFetch = 30;

    public SongRepository(DataContext context) : base(context) { }

    public async Task<IEnumerable<Song>> GetByBandIdAsync(int bandId)
    {
        return await Context.Songs
            .Where(x => x.BandId == bandId)
            .Include(x => x.Band)
            .Include(x => x.Genre)
            .Include(x => x.Genre.ParentGenre)
            .ToListAsync();
    }

    public async Task<IEnumerable<Song>> GetBySearchCriteriasAsync(string text, string searchBy)
    {
        var songs = Context.Songs
            .Include(x => x.Band)
            .Include(x => x.Album);

        if (!string.IsNullOrWhiteSpace(text))
        {
            Expression<Func<Song, bool>> predicate = (item) => true;
            if (string.IsNullOrWhiteSpace(searchBy) || searchBy == "name")
                predicate = (item) => item.SongName.StartsWith(text);
            else if (searchBy == "band")
                predicate = (item) => item.Band.BandName.StartsWith(text);

            return await songs
                .Where(predicate)
                .ToListAsync(); 
        }
        else
        {
            return await songs
                 .OrderBy(t => t.SongName)
                 .Take(defaultAmountToFetch)
                 .ToListAsync();
        }                                               
    }

    public async override Task<Song> FirstOrDefaultAsync(Expression<Func<Song, bool>> predicate)
    {
        return await Context.Set<Song>()
            .Include(x => x.Band)
            .Include(x => x.Album)
            .Include(x => x.Genre)
            .Include(x => x.Genre.ParentGenre)
            .FirstOrDefaultAsync(predicate);
    }
}
