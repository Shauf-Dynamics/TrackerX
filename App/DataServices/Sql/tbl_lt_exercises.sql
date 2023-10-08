USE [MusicTrackerDb]

CREATE TABLE tbl_lt_exercises (
    exercise_id int IDENTITY(1,1) PRIMARY KEY,
    exercise_duration int,
    exercise_description NVARCHAR(MAX),    
    exercise_type_id INT,
    exercise_tempo_low INT,
    exercise_tempo_high INT,
    tempo_type_id INT,        
    song_id INT,
    lesson_Id INT
);
