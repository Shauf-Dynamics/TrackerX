USE [db_TrackerX]

IF COL_LENGTH('tbl_lt_song','year_of_creation') IS NOT NULL
BEGIN
    ALTER TABLE tbl_lt_song
    DROP COLUMN year_of_creation;
END

IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = ' tbl_lt_music_profile'))
BEGIN
    CREATE TABLE tbl_lt_music_profile  (
        music_profile_id    INT IDENTITY(1,1) PRIMARY KEY,        
        music_added_by_id   INT,
        music_type_name     NVARCHAR(64),
        music_asset_id      INT,
        music_publicity_ind BIT,
        created_dttm        DATETIME,
        modified_dttm       DATETIME,
        created_by_user_id  INT,
        modified_by_user_id INT,
        deleled_ind         BIT DEFAULT(0)
    )
END

IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = ' tbl_lt_proposal'))
BEGIN
    CREATE TABLE tbl_lt_proposal (
        proposal_id              INT IDENTITY(1,1) PRIMARY KEY,   
        proposal_status_id       INT,
        proposal_assignee_id     INT,   
        asset_id                 INT,
        asset_type               NVARCHAR(64),    
        response_message         NVARCHAR(512),
        modified_dttm            DATETIME,
        created_by_user_id       INT,
        modified_by_user_id      INT,
        deleled_ind              BIT DEFAULT(0)
    )
END

IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = ' tbl_lt_proposal_status'))
BEGIN
    CREATE TABLE tbl_lt_proposal_status (
        proposal_status_id       INT IDENTITY(1,1) PRIMARY KEY,   
        proposal_status_code     NVARCHAR(32),
        proposal_status_name     NVARCHAR(64),
        modified_dttm            DATETIME,
        created_by_user_id       INT,
        modified_by_user_id      INT,
        deleled_ind              BIT DEFAULT(0)
    )
END

SET IDENTITY_INSERT tbl_lt_proposal_status ON
BEGIN TRY
    INSERT INTO tbl_lt_proposal_status (
        proposal_status_id,
        proposal_status_code,
        proposal_status_name)
    VALUES 
        (1, 'opn', 'Opened'),
        (2, 'comp', 'Completed'),
        (3, 'rej', 'Rejected'),
        (4, 'pend', 'Pending')
END TRY
BEGIN CATCH
    print 'error on attempt to insert dublicates into tbl_lt_proposal_status'
END CATCH
SET IDENTITY_INSERT tbl_lt_proposal_status OFF    