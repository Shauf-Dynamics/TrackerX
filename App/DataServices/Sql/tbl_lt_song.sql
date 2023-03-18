USE [MusicTrackerDb]

CREATE TABLE tbl_lt_song (
    song_id INT IDENTITY(1,1) PRIMARY KEY,
    song_name TEXT,
    band_id INT
)