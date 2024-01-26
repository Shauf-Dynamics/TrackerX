IF OBJECT_ID('dbo.[UQ__tbl_lt_u__A52F4B1D0BD340DF]') IS NOT NULL 
BEGIN
    ALTER TABLE tbl_lt_user_invitations
    DROP CONSTRAINT UQ__tbl_lt_u__A52F4B1D0BD340DF;
END

IF OBJECT_ID('dbo.[UQ__tbl_lt_user_invitations]') IS NULL 
BEGIN
    ALTER TABLE tbl_lt_user_invitations
    ADD CONSTRAINT UQ__tbl_lt_user_invitations UNIQUE (user_invitation_code);
END

IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'tbl_ad_exercise_types'))
BEGIN
    EXEC sp_rename 'tbl_ad_exercise_types', 'tbl_ad_exercise_type';   
END

IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'tbl_ad_user_roles'))
BEGIN
    EXEC sp_rename 'tbl_ad_user_roles', 'tbl_ad_user_role';   
END

IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'tbl_lt_exercises'))
BEGIN
    EXEC sp_rename 'tbl_lt_exercises', 'tbl_lt_exercise';   
END

IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'tbl_lt_lessons'))
BEGIN
    EXEC sp_rename 'tbl_lt_lessons', 'tbl_lt_lesson';   
END

IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'tbl_lt_musics'))
BEGIN
    EXEC sp_rename 'tbl_lt_musics', 'tbl_lt_music';   
END

IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'tbl_lt_songs'))
BEGIN
    EXEC sp_rename 'tbl_lt_songs', 'tbl_lt_song';   
END

IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'tbl_lt_users'))
BEGIN
    EXEC sp_rename 'tbl_lt_users', 'tbl_lt_user';   
END

IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'tbl_lt_user_invitations'))
BEGIN
    EXEC sp_rename 'tbl_lt_user_invitations', 'tbl_lt_user_invitation';   
END