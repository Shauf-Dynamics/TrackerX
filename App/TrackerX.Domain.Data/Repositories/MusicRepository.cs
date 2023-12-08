using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TrackerX.Domain.Entities;
using TrackerX.Domain.Infrastructure;
using TrackerX.Domain.Repositories;

namespace TrackerX.Domain.Data.Repositories
{
    public class MusicRepository : RepositoryBase<Music>, IMusicRepository 
    {
        private const int defaultAmountToFetch = 30;

        public MusicRepository(DataContext context) : base(context) { }

        public async Task<IEnumerable<Music>> GetByBandIdAsync(int bandId)
        {
            return await Context.Songs
                .Where(x => x.BandId == bandId)
                .Include(x => x.Band)
                .Include(x => x.Genre)
                .Include(x => x.Genre.ParentGenre)
                .ToListAsync();
        }

        public async Task<IEnumerable<Music>> GetBySearchCriteriasdAsync(string text, string searchBy)
        {
            var musics = Context.Songs
                .Include(x => x.Band);

            if (!string.IsNullOrWhiteSpace(text))
            {
                Expression<Func<Music, bool>> predicate = (item) => true;
                if (searchBy == "name")
                    predicate = (item) => item.MusicName.StartsWith(text);
                else if (searchBy == "band")
                    predicate = (item) => item.Band.BandName.StartsWith(text);

                return await musics
                    .Where(predicate)
                    .ToListAsync(); 
            }
            else
            {
                return await musics
                     .Take(defaultAmountToFetch)
                     .ToListAsync();
            }                                               
        }

        public async override Task<Music> FirstOrDefaultAsync(Expression<Func<Music, bool>> predicate)
        {
            return await Context.Set<Music>()
                .Include(x => x.Band)
                .Include(x => x.Genre)
                .Include(x => x.Genre.ParentGenre)
                .FirstOrDefaultAsync(predicate);
        }
    }
}
