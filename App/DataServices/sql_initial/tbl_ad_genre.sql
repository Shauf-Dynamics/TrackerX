USE [db_TrackerX]

IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'tbl_ad_genre'))
BEGIN
    CREATE TABLE tbl_ad_genre (
        genre_id            INT IDENTITY(1,1) PRIMARY KEY,
        genre_name          NVARCHAR(64),
        genre_parent_id     INT,
        created_dttm        DATETIME,
        modified_dttm       DATETIME,
        created_by_user_id  INT,
        modified_by_user_id INT,
        deleled_ind         BIT DEFAULT(0)
    )

    ALTER TABLE tbl_ad_genre
    ADD CONSTRAINT FK_Genre_to_Genre FOREIGN KEY (genre_parent_id)
    REFERENCES tbl_ad_genre (genre_id)

    ALTER TABLE tbl_ad_genre
    ADD CONSTRAINT UN_GenreName UNIQUE (genre_name);   
END