USE [MusicTrackerDb]

CREATE TABLE tbl_lt_account_role (
    account_role_id INT IDENTITY(1,1) PRIMARY KEY,
    account_role_code NVARCHAR(10),
    account_role_name TEXT
);

