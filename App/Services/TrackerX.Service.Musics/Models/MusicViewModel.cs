namespace TrackerX.Services.Musics.Models;

public class MusicViewModel
{
    public int MusicId { get; set; }

    public string MusicName { get; set; }

    public string BandName { get; set; }

    public int Tempo { get; set; }

    public bool IsInstrumental { get; set; }

    public int WritingYear { get; set; }

    public string Genre { get; set; }

    public string Subgenre { get; set; }
}
