USE [db_TrackerX]

IF COL_LENGTH('tbl_lt_song','year_of_creation') IS NOT NULL
BEGIN
    ALTER TABLE tbl_lt_song
    DROP COLUMN year_of_creation;
END