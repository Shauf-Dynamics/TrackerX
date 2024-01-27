USE [db_TrackerX]

IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'tbl_ad_user_role'))
BEGIN
    CREATE TABLE tbl_ad_user_role (
        user_role_id        INT IDENTITY(1,1) PRIMARY KEY,
        user_role_code      NVARCHAR(8),
        user_role_name      NVARCHAR(64),
        created_dttm        DATETIME,
        modified_dttm       DATETIME,
        created_by_user_id  INT,
        modified_by_user_id INT,
        deleled_ind         BIT DEFAULT(0)
    )
END

