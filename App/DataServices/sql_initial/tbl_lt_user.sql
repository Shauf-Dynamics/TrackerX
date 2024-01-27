USE [db_TrackerX]

IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = ' tbl_lt_user'))
BEGIN
    CREATE TABLE tbl_lt_user (
        user_id                INT IDENTITY(1,1) PRIMARY KEY,
        user_name              NVARCHAR(64),
        user_email             NVARCHAR(128),
        user_password_hash     NVARCHAR(512),
        user_registration_date DATETIME,
        user_role_id           INT,
        created_dttm           DATETIME,
        modified_dttm          DATETIME,
        created_by_user_id     INT,
        modified_by_user_id    INT,
        deleled_ind            BIT DEFAULT(0)
    )
END
