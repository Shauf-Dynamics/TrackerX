using AutoMapper;
using TrackerX.Services.Lessons.Models;
using TrackerX.Domain.Entities;

namespace TrackerX.Service.Lessons.Infrastructure;

public class LessonMapper : Profile
{
    public LessonMapper()
    {
        CreateMap<CreateExerciseModel, Exercise>()
            .ForMember(dest => dest.ExerciseType, opt => opt.Ignore())
            .ForMember(dest => dest.TempoType, opt => opt.Ignore())
            .ForMember(dest => dest.Song, opt => opt.Ignore())
            .ForMember(dest => dest.Lesson, opt => opt.Ignore());
    }
}
