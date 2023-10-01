using Microsoft.EntityFrameworkCore;
using TrackerX.Domain.Entities;
using TrackerX.Domain.Infrastructure;
using TrackerX.Domain.Repositories;

namespace TrackerX.Domain.Data.Repositories
{
    public class SongRepository : BaseRepository<Song>, ISongRepository 
    {
        public SongRepository(DataContext context) : base(context) { }
    }
}
