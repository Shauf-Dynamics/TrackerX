namespace TrackerX.Domain.Entities
{
    public class Song
    {
        public int Id { get; set; }

        public int Name { get; set; }

        public int BandId { get; set; }

        public Band Band { get; set; }
    }
}
