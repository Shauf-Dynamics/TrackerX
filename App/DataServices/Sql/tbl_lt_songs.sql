USE [MusicTrackerDb]

CREATE TABLE tbl_lt_songs (
    song_id          INT IDENTITY(1,1) PRIMARY KEY,
    song_name        NVARCHAR(128) NOT NULL,
    band_id          INT NOT NULL,
    tempo            INT NULL,
    year_of_creation INT NULL,
    instrumental_ind BIT DEFAULT(0),
    genre_id         INT NULL,
    album_id         INT NULL
)