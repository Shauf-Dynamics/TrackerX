namespace TrackerX.Domain.Entities
{
    public class Record : BaseEntity
    {
        public int Id { get; set; }

        public DateTime RecordCreated { get; set; }

     //   public int OwnerId { get; set; }

        public ICollection<Exercise> Exercises { get; set; }

        public bool IsDeleted { get; set; }
    }


}
