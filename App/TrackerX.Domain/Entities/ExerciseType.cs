namespace TrackerX.Domain.Entities;

public class ExerciseType : BaseEntity
{
    public int ExerciseTypeId { get; set; }

    public string ExerciseTypeCode { get; set; }

    public string ExerciseTypeName { get; set; }
}
