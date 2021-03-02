CREATE OR ALTER PROCEDURE add_cos_cumparaturi
    @userId INT
AS
BEGIN
    IF NOT EXISTS (
        SELECT * 
        FROM Cos_cumparaturi
        WHERE userId = @userId
    )

    INSERT INTO Cos_cumparaturi(userId, odate)
    VALUES(@userId, SYSDATETIME())
END
GO