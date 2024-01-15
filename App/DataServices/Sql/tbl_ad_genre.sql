USE [MusicTrackerDb]

CREATE TABLE tbl_ad_genre (
    genre_id        INT IDENTITY(1,1) PRIMARY KEY,
    genre_name      NVARCHAR(64),
    genre_parent_id INT
)

ALTER TABLE tbl_ad_genre
ADD CONSTRAINT FK_Genre_to_Genre FOREIGN KEY (genre_parent_id)
REFERENCES tbl_ad_genre (genre_id)

ALTER TABLE tbl_ad_genre
ADD CONSTRAINT UN_GenreName UNIQUE (genre_name);   