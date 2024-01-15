using TrackerX.Services.Lessons.Models;

namespace TrackerX.Services.Lessons
{
    public interface ILessonService
    {
        Task Create(CreateLessonModel model);
    }
}
