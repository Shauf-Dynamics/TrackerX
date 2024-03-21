using TrackerX.Domain.Entities;
using TrackerX.Domain.Infrastructure;
using TrackerX.Domain.Repositories;

namespace TrackerX.Domain.Data.Repositories;

public class MusicProfileRepository : RepositoryBase<MusicProfile>, IMusicProfileRepository
{
    public MusicProfileRepository(DataContext context) : base(context) { }    
}
