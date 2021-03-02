CREATE OR ALTER FUNCTION count_products(@userName NVARCHAR(50))
RETURNS INT
AS
    BEGIN
        DECLARE 
            @count INT,
            @userId INT,
            @cosId INT;

        SET @count = 0;

        SELECT @userId = userId
        FROM Users
        WHERE @userName = userName;

        SELECT @cosId = cosId
        FROM Cos_cumparaturi
        WHERE @userId = userId;

        IF EXISTS (
            SELECT * 
            FROM Products p, Cos_cumparaturi c, Item i
            WHERE c.cosId = i.cosId AND
                i.productId = p.productId AND
                i.cosId = @cosId)

            SELECT @count = COUNT(p.price)
            FROM Products p, Cos_cumparaturi c, Item i
            WHERE c.cosId = i.cosId AND
                i.productId = p.productId AND
                i.cosId = @cosId;

        RETURN @count;
    END
GO

exec count_products @userName="ana";