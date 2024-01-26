USE [db_TrackerX]

SET IDENTITY_INSERT tbl_ad_user_role ON

BEGIN TRY
    INSERT INTO tbl_ad_user_role (
        user_role_id,
        user_role_code,
        user_role_name)
    VALUES 
        (1, 'SA', 'Superadmin'),
        (2, 'Ad', 'Admin'),
        (3, 'Cl', 'Client')
END TRY
BEGIN CATCH
    print 'error on attempt to insert dublicates into tbl_ad_user_role'
END CATCH

SET IDENTITY_INSERT tbl_ad_user_role OFF    
