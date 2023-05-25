USE [MusicTrackerDb]

CREATE TABLE tbl_lt_account (
    account_id INT IDENTITY(1,1) PRIMARY KEY,
    account_token TEXT,
    account_name TEXT,
    registration_dttm INT,
    is_deactivated BIT DEFAULT 0,
    role_id INT
);