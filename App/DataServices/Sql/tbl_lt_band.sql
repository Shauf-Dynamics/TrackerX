USE [MusicTrackerDb]

CREATE TABLE tbl_lt_band (
    band_id INT IDENTITY(1,1) PRIMARY KEY,
    band_name TEXT
)

ALTER TABLE tbl_lt_band
ALTER COLUMN band_name NVARCHAR(MAX);