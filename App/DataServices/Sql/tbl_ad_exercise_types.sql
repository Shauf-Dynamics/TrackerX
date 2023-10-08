USE [MusicTrackerDb]

CREATE TABLE tbl_ad_exercise_types (
    exercise_type_id INT IDENTITY(1,1) PRIMARY KEY,
    exercise_type_cd VARCHAR(8),
    exercise_type_name VARCHAR(64)
)