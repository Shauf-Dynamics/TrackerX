using TrackerX.Core.Services.Lessons.Models;

namespace TrackerX.Core.Services.Lessons
{
    public interface ILessonService
    {
        Task Create(CreateLessonModel model);
    }
}
