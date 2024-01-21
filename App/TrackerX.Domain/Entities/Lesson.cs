namespace TrackerX.Domain.Entities;

public class Lesson : BaseEntity
{
    public int LessonId { get; set; }

    public DateTime LessonDate { get; set; }

    public ICollection<Exercise> Exercises { get; set; }
}
