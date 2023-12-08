namespace TrackerX.Domain.Entities
{
    public class Album : BaseEntity
    {
        public int AlbumId { get; set; }

        public string AlbumName { get; set; }

        public int WritingYear { get; set; }

        public int GenreId { get; set; }

        public Genre Genre { get; set; }

        public int BandId { get; set; }

        public Band Band { get; set; }

        public ICollection<Music> Musics { get; set; }
    }
}
