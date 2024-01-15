using AutoMapper;
using TrackerX.Services.Lessons.Models;
using TrackerX.Domain.Entities;
using TrackerX.Domain.Repositories;

namespace TrackerX.Services.Lessons
{
    public class LessonService : ILessonService
    {
        private readonly IMapper _mapper;
        private readonly ILessonRepository _lessonRepository;
        private readonly IExerciseRepository _exerciseRepository;

        public LessonService(ILessonRepository lessonRepository, IExerciseRepository exerciseRepository, IMapper mapper)
        {
            _lessonRepository = lessonRepository;
            _exerciseRepository = exerciseRepository;
            _mapper = mapper;
        }

        public async Task Create(CreateLessonModel model)
        {
            var lesson = new Lesson();
            lesson.LessonDate = model.Date;

            _lessonRepository.Create(lesson);
            await _lessonRepository.SaveChangesAsync();

            foreach (var item in model.Exercises)
            {
                var exercise = _mapper.Map<Exercise>(item);
                exercise.LessonId = lesson.LessonId;
                _exerciseRepository.Create(exercise);
            }            

            await _exerciseRepository.SaveChangesAsync();
        }
    }
}
