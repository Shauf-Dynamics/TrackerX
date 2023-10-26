USE [MusicTrackerDb]

CREATE TABLE tbl_lt_user_invitation (
    user_invitation_id INT IDENTITY(1,1) PRIMARY KEY,
    user_invitation_user_id INT DEFAULT NULL UNIQUE,
    user_invitation_code NVARCHAR(256),
    user_invitation_due_date DATE,
    invitation_aborted_ind BIT DEFAULT(0)
);

ALTER TABLE tbl_lt_user_invitation
ADD invitation_accepted_date DATE
