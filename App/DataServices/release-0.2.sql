USE [db_TrackerX]

IF COL_LENGTH('tbl_lt_song','year_of_creation') IS NOT NULL
BEGIN
    ALTER TABLE tbl_lt_song
    DROP COLUMN year_of_creation;
END

IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = ' tbl_lt_music_profile'))
BEGIN
    CREATE TABLE tbl_lt_music_profile  (
        music_profile_id    INT IDENTITY(1,1) PRIMARY KEY,        
        music_added_by_id   INT,
        music_type_name     NVARCHAR(64),
        music_asset_id      INT,
        music_publicity_ind BIT,
        created_dttm        DATETIME,
        modified_dttm       DATETIME,
        created_by_user_id  INT,
        modified_by_user_id INT,
        deleled_ind         BIT DEFAULT(0)
    )
END
