USE [MusicTrackerDb]

CREATE TABLE tbl_lt_users (
    user_id INT IDENTITY(1,1) PRIMARY KEY,
    user_name NVARCHAR(64),
    user_email  NVARCHAR(128),
    user_password_hash TEXT,
    user_registration_date DATETIME,
    user_role_id INT
)

ALTER TABLE tbl_lt_users 
ALTER COLUMN user_password_hash NVARCHAR(512)