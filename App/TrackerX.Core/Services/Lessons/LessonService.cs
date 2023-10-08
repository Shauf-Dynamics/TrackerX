using TrackerX.Core.Services.Lessons.Models;
using TrackerX.Domain.Entities;
using TrackerX.Domain.UnitOfWorks;

namespace TrackerX.Core.Services.Lessons
{
    public class LessonService : ILessonService
    {
        private readonly IAddLessonUnitOfWork _addLessonUnitOfWork;

        public LessonService(IAddLessonUnitOfWork addLessonUnitOfWork)
        {
            _addLessonUnitOfWork = addLessonUnitOfWork;
        }

        public async Task Create(CreateLessonModel model)
        {
            var lesson = new Lesson();
            lesson.LessonDate = model.Date;

            _addLessonUnitOfWork.LessonRepository.Create(lesson);

            await _addLessonUnitOfWork.Commit();
        }
    }
}
