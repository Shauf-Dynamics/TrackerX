USE [MusicTrackerDb]

CREATE TABLE tbl_lt_band (
    band_id   INT IDENTITY(1,1) PRIMARY KEY,
    band_name NVARCHAR(256)
)