using TrackerX.Domain.Entities;
using TrackerX.Domain.Infrastructure;
using TrackerX.Domain.Repositories;

namespace TrackerX.Domain.Data.Repositories;

public class LessonRepository : RepositoryBase<Lesson>, ILessonRepository
{
    public LessonRepository(DataContext context) : base(context) { }
}
