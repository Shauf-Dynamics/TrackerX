namespace TrackerX.Core.Services.Musics.Models
{
    public class CreateMusicModel
    {
        public string Name { get; set; }

        public int WritingYear { get; set; }

        public int Tempo { get; set; }

        public bool IsInstrumental { get; set; } = false;

        public int GenreId { get; set; }

        public int BandId { get; set; }
    }
}
