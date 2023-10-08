USE [MusicTrackerDb]

SET IDENTITY_INSERT tbl_ad_user_roles ON

INSERT INTO tbl_ad_user_roles (
    user_role_id,
    user_role_code,
    user_role_name)
VALUES 
    (1, 'SA', 'Superadmin'),
    (2, 'Ad', 'Admin'),
    (3, 'Cl', 'Client'),

SET IDENTITY_INSERT tbl_ad_user_roles OFF    
