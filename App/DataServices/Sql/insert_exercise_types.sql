USE [MusicTrackerDb]

SET IDENTITY_INSERT tbl_ad_exercise_types ON

INSERT INTO tbl_ad_exercise_types (
    exercise_type_id,
    exercise_type_cd,
    exercise_type_name)
VALUES 
    (1, 'gt', 'guitar'),
    (2, 'th', 'theory'),
    (3, 'imp', 'improvisation'),
    (4, 'comp', 'compositioning')

SET IDENTITY_INSERT tbl_ad_exercise_types OFF    