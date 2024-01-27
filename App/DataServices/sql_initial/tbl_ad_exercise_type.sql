USE [db_TrackerX]

IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'tbl_ad_exercise_type'))
BEGIN
    CREATE TABLE tbl_ad_exercise_type (
        exercise_type_id    INT IDENTITY(1,1) PRIMARY KEY,
        exercise_type_cd    VARCHAR(8),
        exercise_type_name  VARCHAR(64),
        created_dttm        DATETIME,
        modified_dttm       DATETIME,
        created_by_user_id  INT,
        modified_by_user_id INT,
        deleled_ind         BIT DEFAULT(0)
    )
END

