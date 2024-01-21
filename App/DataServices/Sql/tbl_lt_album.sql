USE [MusicTrackerDb]

IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'MusicTrackerDb' AND  TABLE_NAME = 'tbl_lt_album'))
BEGIN
    CREATE TABLE tbl_lt_album (
        album_id         INT IDENTITY(1,1) PRIMARY KEY,
        album_name       NVARCHAR(256),
        band_id          INT,
        genre_id         INT,
        year_of_creation INT
    )
END
