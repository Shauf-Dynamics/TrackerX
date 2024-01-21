USE [MusicTrackerDb]

IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'MusicTrackerDb' AND  TABLE_NAME = 'tbl_ad_exercise_types'))
BEGIN
    CREATE TABLE tbl_ad_exercise_types (
        exercise_type_id   INT IDENTITY(1,1) PRIMARY KEY,
        exercise_type_cd   VARCHAR(8),
        exercise_type_name VARCHAR(64)
    )
END

