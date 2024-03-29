﻿namespace TrackerX.Services.Musics.Models;

public class SongDetailsResult
{
    public int SongId { get; set; }

    public string Name { get; set; }

    public string Band { get; set; }

    public string Album { get; set; }

    public int Tempo { get; set; }

    public bool IsInstrumental { get; set; }

    public string Genre { get; set; }

    public string Subgenre { get; set; }
}
