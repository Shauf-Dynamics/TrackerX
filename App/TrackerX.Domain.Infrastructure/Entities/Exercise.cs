namespace TrackerX.Domain.Entities
{
    public class Exercise : BaseEntity
    {
        public int ExerciseId { get; set; }

        public DateTime Duration { get; set; }

        public string Description { get; set; }

        public int TempoLow { get; set; }

        public int TempoHigh { get; set; }

        public int TempoTypeId { get; set; }

        public TempoType TempoType { get; set; }

        public int ExerciseTypeId { get; set; }

        public ExerciseType ExerciseType { get; set; }

        public int SongId { get; set; }

        public Song Song { get; set; }

        public int LessonId { get; set; }

        public Lesson Lesson { get; set; }
    }        
}
