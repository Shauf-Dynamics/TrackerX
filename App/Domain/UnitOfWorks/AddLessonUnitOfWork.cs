using TrackerX.Domain.Data.Repositories;
using TrackerX.Domain.Infrastructure;
using TrackerX.Domain.Repositories;
using TrackerX.Domain.UnitOfWorks;

namespace TrackerX.Domain.Data.UnitOfWorks
{
    public class AddLessonUnitOfWork : IAddLessonUnitOfWork
    {
        private readonly DataContext _context;

        private readonly ILessonRepository _lessonRepository;

        public AddLessonUnitOfWork(DataContext context)
        {
            _context = context;

            _lessonRepository = new LessonRepository(context);
        }

        public ILessonRepository LessonRepository => _lessonRepository;

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }
    }
}
