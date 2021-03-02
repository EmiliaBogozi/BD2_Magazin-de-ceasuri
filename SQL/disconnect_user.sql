
--Buton Deconectare

CREATE OR ALTER PROCEDURE disconnect_user
    @user_name NVARCHAR(50)
AS
    UPDATE Users
    SET conectat = 0
    WHERE userName = @user_name
GO