USE [MusicTrackerDb]

IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'MusicTrackerDb' AND  TABLE_NAME = 'tbl_lt_band'))
BEGIN
    CREATE TABLE tbl_lt_band (
        band_id   INT IDENTITY(1,1) PRIMARY KEY,
        band_name NVARCHAR(256)
    )
END
