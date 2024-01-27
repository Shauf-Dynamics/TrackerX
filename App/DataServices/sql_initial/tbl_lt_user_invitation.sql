USE [db_TrackerX]

IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = ' tbl_lt_user_invitation'))
BEGIN
    CREATE TABLE tbl_lt_user_invitation (
        user_invitation_id       INT IDENTITY(1,1) PRIMARY KEY,
        user_invitation_user_id  INT DEFAULT NULL UNIQUE,
        user_invitation_code     NVARCHAR(256),
        user_invitation_due_date DATE,
        invitation_aborted_ind   BIT DEFAULT(0),
        invitation_accepted_date DATE,
        created_dttm             DATETIME,
        modified_dttm            DATETIME,
        created_by_user_id       INT,
        modified_by_user_id      INT,
        deleled_ind              BIT DEFAULT(0)
    );
END

ALTER TABLE tbl_lt_user_invitation
ADD CONSTRAINT UQ__tbl_lt_user_invitation UNIQUE (user_invitation_code);