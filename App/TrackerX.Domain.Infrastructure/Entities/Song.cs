namespace TrackerX.Domain.Entities
{
    public class Song : BaseEntity
    {
        public int SongId { get; set; }

        public string SongName { get; set; }

        public int BandId { get; set; }

        public Band Band { get; set; }
    }
}
