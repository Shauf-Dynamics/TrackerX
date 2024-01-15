USE [MusicTrackerDb]

CREATE TABLE tbl_ad_user_roles (
    user_role_id   INT IDENTITY(1,1) PRIMARY KEY,
    user_role_code NVARCHAR(8),
    user_role_name NVARCHAR(64)
)
