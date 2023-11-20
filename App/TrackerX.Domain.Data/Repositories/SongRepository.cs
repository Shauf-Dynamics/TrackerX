using Microsoft.EntityFrameworkCore;
using TrackerX.Domain.Entities;
using TrackerX.Domain.Infrastructure;
using TrackerX.Domain.Repositories;

namespace TrackerX.Domain.Data.Repositories
{
    public class SongRepository : RepositoryBase<Song>, ISongRepository 
    {
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
    }
}
