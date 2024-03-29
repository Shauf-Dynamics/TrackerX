USE [db_TrackerX]

SET IDENTITY_INSERT tbl_ad_exercise_type ON

BEGIN TRY
    INSERT INTO tbl_ad_exercise_type (
        exercise_type_id,
        exercise_type_cd,
        exercise_type_name)
    VALUES 
        (1, 'gt', 'guitar'),
        (2, 'th', 'theory'),
        (3, 'imp', 'improvisation'),
        (4, 'comp', 'compositioning')
END TRY
BEGIN CATCH
    print 'error on attempt to insert dublicates into tbl_ad_exercise_type'
END CATCH

SET IDENTITY_INSERT tbl_ad_exercise_type OFF    