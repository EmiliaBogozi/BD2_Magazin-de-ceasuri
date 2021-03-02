CREATE OR ALTER PROCEDURE login_User
	@user_name NVARCHAR(50),
	@password NVARCHAR(20)
AS
	SELECT userName, pass
    FROM Users 
	WHERE userName = @user_name
	    AND pass = @password
GO