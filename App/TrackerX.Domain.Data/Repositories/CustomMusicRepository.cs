using TrackerX.Domain.Entities;
using TrackerX.Domain.Infrastructure;
using TrackerX.Domain.Repositories;

namespace TrackerX.Domain.Data.Repositories;

public class CustomMusicRepository: RepositoryBase<CustomMusic>, ICustomMusicRepository
{
    public CustomMusicRepository(DataContext context) : base(context) { }
}
