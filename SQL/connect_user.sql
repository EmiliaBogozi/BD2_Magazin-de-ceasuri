CREATE OR ALTER PROCEDURE connect_user
    @user_name NVARCHAR(50)
AS
    UPDATE Users
    SET conectat = 1
    WHERE userName = @user_name
GO