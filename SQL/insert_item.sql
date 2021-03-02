
CREATE OR ALTER PROCEDURE insert_item
    @userName NVARCHAR(50),
    @productId INT
AS
BEGIN
    DECLARE 
        @cosId INT,
        @userId INT
    SELECT @userId = userId
    FROM Users
    WHERE @userName = userName;

    SELECT @cosId = cosId
    FROM Cos_cumparaturi
    WHERE @userId = userId;

    INSERT INTO Item(cosId, productId)
    VALUES(@cosId, @productId)
END
GO

--exec insert_item @userName="ana", @productId=2;

