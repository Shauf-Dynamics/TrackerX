using TrackerX.Domain.Entities;
using TrackerX.Domain.Infrastructure;
using TrackerX.Domain.Repositories;

namespace TrackerX.Domain.Data.Repositories;

public class MusicRepository: RepositoryBase<Music>, IMusicRepository
{
    public MusicRepository(DataContext context) : base(context) { }
}
