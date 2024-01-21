namespace TrackerX.Services.Lessons.Models;

public class CreateLessonModel
{
    public DateTime Date { get; set; }

    public IEnumerable<CreateExerciseModel> Exercises { get; set; }
}    
