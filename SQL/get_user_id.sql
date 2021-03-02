
CREATE OR ALTER FUNCTION get_user_id(@userName NVARCHAR(50))
RETURNS INT
AS
    BEGIN
        DECLARE
            @user_id INT;

        SET @user_id = 0;

        SELECT @user_id = userId
        FROM Users
        WHERE userName = @userName

        RETURN @user_id;
    END
GO