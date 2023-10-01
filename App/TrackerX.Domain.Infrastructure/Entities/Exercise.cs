namespace TrackerX.Domain.Entities
{
    public sealed class Exercise
    {
        public int Id { get; set; }

        public DateTime Duration { get; set; }

        public string Name { get; set; }

        public int TypeId { get; set; }

        public int TempoLow { get; set; }

        public int TempoHigh { get; set; }

        public int RecordId { get; set; }

        public Record Record { get; set; }

        public int ExerciseTypeId { get; set; }

        public ExerciseType ExerciseType { get; set; }

        public bool IsDeleted { get; set; }
    }        
}
