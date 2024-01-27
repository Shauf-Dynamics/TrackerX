USE [db_TrackerX]

IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = ' tbl_lt_song'))
BEGIN
    CREATE TABLE tbl_lt_song (
        song_id             INT IDENTITY(1,1) PRIMARY KEY,
        song_name           NVARCHAR(128) NOT NULL,
        band_id             INT NOT NULL,
        tempo               INT NULL,
        year_of_creation    INT NULL,
        instrumental_ind    BIT DEFAULT(0),
        genre_id            INT NULL,
        album_id            INT NULL,
        created_dttm        DATETIME,
        modified_dttm       DATETIME,
        created_by_user_id  INT,
        modified_by_user_id INT,
        deleled_ind         BIT DEFAULT(0)
    )
END
