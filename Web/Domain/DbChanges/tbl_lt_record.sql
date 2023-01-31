USE [MusicTrackerDb]
CREATE TABLE tbl_lt_record (
    record_id int IDENTITY(1,1) PRIMARY KEY,
    record_date DATETIME,
    deleted_ind BIT 
);

ALTER TABLE [tbl_lt_record]
    ADD CONSTRAINT DF_record_delete_ind
    DEFAULT 0 FOR deleted_ind
