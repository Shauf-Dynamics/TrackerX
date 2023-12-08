namespace TrackerX.Domain.Entities
{
    public sealed class Music : BaseEntity
    {
        public int MusicId { get; set; }

        public string MusicName { get; set; }

        public int BandId { get; set; }

        public Band Band { get; set; }

        public int GenreId { get; set; }

        public Genre Genre { get; set; }

        public int? AlbumId { get; set; }

        public Album Album { get; set; }

        public int Tempo { get; set; }

        public bool IsInstrumental { get; set; }

        public int WritingYear { get; set; }
    }
}
