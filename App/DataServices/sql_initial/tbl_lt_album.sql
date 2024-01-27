USE [db_TrackerX]

IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'tbl_lt_album'))
BEGIN
    CREATE TABLE tbl_lt_album (
        album_id            INT IDENTITY(1,1) PRIMARY KEY,
        album_name          NVARCHAR(256),
        band_id             INT,
        genre_id            INT,
        year_of_creation    INT,
        created_dttm        DATETIME,
        modified_dttm       DATETIME,
        created_by_user_id  INT,
        modified_by_user_id INT,
        deleled_ind         BIT DEFAULT(0)
    )
END
