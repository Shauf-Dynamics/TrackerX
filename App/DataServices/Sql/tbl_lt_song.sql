USE [MusicTrackerDb]

CREATE TABLE tbl_lt_song (
    song_id INT IDENTITY(1,1) PRIMARY KEY,
    song_name TEXT,
    band_id INT
)

ALTER TABLE tbl_lt_song
ADD tempo INT 

ALTER TABLE tbl_lt_song
ADD year INT

ALTER TABLE tbl_lt_song
ADD instrumental_ind BIT

ALTER TABLE tbl_lt_song
ADD genre_id INT