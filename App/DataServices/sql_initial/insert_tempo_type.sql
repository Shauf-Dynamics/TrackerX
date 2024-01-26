USE [db_TrackerX]

SET IDENTITY_INSERT tbl_ad_tempo_type ON

BEGIN TRY
    INSERT INTO tbl_ad_tempo_type (
        tempo_type_id,
        tempo_type_code,
        tempo_type_name)
    VALUES 
        (1, 'BPM', 'Beats Per Minute'),
        (2, 'Pct', 'Percentage')
END TRY
BEGIN CATCH
    print 'error on attempt to insert dublicates into tbl_ad_tempo_type'
END CATCh

SET IDENTITY_INSERT tbl_ad_tempo_type OFF    
