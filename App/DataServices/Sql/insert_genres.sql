USE [MusicTrackerDb]

SET IDENTITY_INSERT tbl_ad_genre ON

/* INSERT MAIN GENRES */
INSERT INTO tbl_ad_genre (
    genre_id,
    genre_name,
    genre_parent_id)
VALUES 
    (1, 'Rock', null),
    (2, 'Metal', null),
    (3, 'Blues', null),
    (4, 'Jazz', null),
    (5, 'Folk', null),
    (6, 'Classic', null),
    (7, 'Instrumental', null),
    (8, 'Pop', null);

SET IDENTITY_INSERT tbl_ad_genre OFF    

/* INSERT SUB-GENRES */
INSERT INTO tbl_ad_genre (
    genre_name,
    genre_parent_id)
VALUES 
    ('Heavy Metal', 2),
    ('Thrash Metal', 2);
    