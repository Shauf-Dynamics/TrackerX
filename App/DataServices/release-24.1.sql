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
