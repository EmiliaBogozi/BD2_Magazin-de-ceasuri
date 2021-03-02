CREATE OR ALTER PROCEDURE create_new_account
    @user_name NVARCHAR(50),
    @password NVARCHAR(20),
    @email NVARCHAR(50),
    @telefon INT
AS
BEGIN
    IF NOT EXISTS (
        SELECT * 
        FROM Users
        WHERE userName = @user_name
    )

    INSERT INTO Users(userName, pass, email, telefon, conectat)
    VALUES (@user_name, @password, @email, @telefon, 0)
END
GO