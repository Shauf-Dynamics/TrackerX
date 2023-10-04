USE [MusicTrackerDb]

CREATE TABLE tbl_lt_album (
    album_id INT IDENTITY(1,1) PRIMARY KEY,
    album_name TEXT,
    band_id INT,
    genre_id INT,
    year_of_creation INT
)