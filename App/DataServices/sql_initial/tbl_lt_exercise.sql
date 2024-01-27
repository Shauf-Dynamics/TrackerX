USE [db_TrackerX]

IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'tbl_lt_exercise'))
BEGIN
    CREATE TABLE tbl_lt_exercise (
        exercise_id          INT IDENTITY(1,1) PRIMARY KEY,
        exercise_duration    INT,
        exercise_description NVARCHAR(MAX),    
        exercise_type_id     INT,
        exercise_tempo_low   INT,
        exercise_tempo_high  INT,
        tempo_type_id        INT,        
        song_id              INT,
        lesson_Id            INT,
        created_dttm         DATETIME,
        modified_dttm        DATETIME,
        created_by_user_id   INT,
        modified_by_user_id  INT,
        deleled_ind          BIT DEFAULT(0)
    );
END
