USE [db_TrackerX]

IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'db_TrackerX' AND  TABLE_NAME = ' tbl_lt_lessons'))
BEGIN
    CREATE TABLE tbl_lt_lessons (
        lesson_id   INT IDENTITY(1,1) PRIMARY KEY,
        lesson_date DATE    
    )
END