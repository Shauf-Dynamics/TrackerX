namespace TrackerX.Services.Lessons.Models;

public class CreateExerciseModel
{
    public string Description { get; set; }

    public int Duration { get; set; }

    public int TempoLow { get; set; }

    public int TempoHigh { get; set; }

    public int TempoTypeId { get; set; }

    public int ExerciseTypeId { get; set; }

    public int? SongId { get; set; }        
}
