namespace TrackerX.Core.Services.Songs.Models
{
    public class SongViewModel
    {
        public int SongId { get; set; }

        public string SongName { get; set; }

        public string BandName { get; set; }

        public int Tempo { get; set; }

        public bool IsInstrumental { get; set; }

        public int WritingYear { get; set; }

        public string Genre { get; set; }

        public string Subgenre { get; set; }
    }
}
