USE [MusicTrackerDb]

CREATE TABLE tbl_lt_exercise (
    exercise_id int IDENTITY(1,1) PRIMARY KEY,
    exercise_duration DATETIME,
    exercise_name TEXT,
    exercise_type_id INT,
    exercise_tempo_low INT,
    exercise_tempo_high INT,
    deleted_ind BIT 
);