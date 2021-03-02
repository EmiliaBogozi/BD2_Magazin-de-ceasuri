
--Procedura pentru eliminarea produsului selectat din cosul unui
--utilizator

CREATE OR ALTER PROCEDURE delete_item
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

    DELETE TOP(1)
    FROM Item 
    WHERE cosId = @cosId AND @productId = productId;
END
GO

exec delete_item @userName="ana", @productId=2;

