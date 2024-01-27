USE [db_TrackerX]

IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'tbl_lt_band'))
BEGIN
    CREATE TABLE tbl_lt_band (
        band_id             INT IDENTITY(1,1) PRIMARY KEY,
        band_name           NVARCHAR(256),
        created_dttm        DATETIME,
        modified_dttm       DATETIME,
        created_by_user_id  INT,
        modified_by_user_id INT,
        deleled_ind         BIT DEFAULT(0)
    )
END
