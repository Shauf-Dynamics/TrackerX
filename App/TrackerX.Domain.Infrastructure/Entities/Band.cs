namespace TrackerX.Domain.Entities
{
    public sealed class Band : BaseEntity
    {
        public int BandId { get; set; }

        public string BandName { get; set; }

        public ICollection<Song> Songs { get; set; }
    }
}
