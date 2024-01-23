USE [db_TrackerX]

IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'db_TrackerX' AND  TABLE_NAME = ' tbl_lt_users'))
BEGIN
    CREATE TABLE tbl_lt_users (
        user_id                INT IDENTITY(1,1) PRIMARY KEY,
        user_name              NVARCHAR(64),
        user_email             NVARCHAR(128),
        user_password_hash     NVARCHAR(512),
        user_registration_date DATETIME,
        user_role_id           INT
    )
END
