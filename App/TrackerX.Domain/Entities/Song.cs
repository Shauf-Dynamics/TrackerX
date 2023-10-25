namespace TrackerX.Domain.Entities
{
    public sealed class Song : BaseEntity
    {
        public int SongId { get; set; }

        public string SongName { get; set; }

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
