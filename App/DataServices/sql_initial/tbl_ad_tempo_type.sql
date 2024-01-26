USE [db_TrackerX]

IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'tbl_ad_tempo_type'))
BEGIN
    CREATE TABLE tbl_ad_tempo_type (
        tempo_type_id   INT IDENTITY(1,1) PRIMARY KEY,
        tempo_type_code NVARCHAR(8),
        tempo_type_name NVARCHAR(64)
    )
END