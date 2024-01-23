USE [db_TrackerX]

IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'db_TrackerX' AND  TABLE_NAME = ' tbl_lt_musics'))
BEGIN
    CREATE TABLE tbl_lt_musics (
        music_id            INT IDENTITY(1,1) PRIMARY KEY,    
        music_description   NVARCHAR(512) NOT NULL,
        music_author        NVARCHAR(128) NULL,
        own_ind             BIT NULL,
        instrumental_ind    BIT DEFAULT(0),
        tempo               INT,
        genre_id            INT,
        year_of_creation    INT
    )
END
