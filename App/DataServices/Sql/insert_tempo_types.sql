USE [MusicTrackerDb]

SET IDENTITY_INSERT tbl_ad_tempo_type ON

INSERT INTO tbl_ad_tempo_type (
    tempo_type_id,
    tempo_type_code,
    tempo_type_name)
VALUES 
    (1, 'BPM', 'Beats Per Minute'),
    (2, 'Pct', 'Percentage')

SET IDENTITY_INSERT tbl_ad_tempo_type OFF    
