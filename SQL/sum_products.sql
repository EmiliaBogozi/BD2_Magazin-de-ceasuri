CREATE OR ALTER FUNCTION sum_products(@userName NVARCHAR(50))
RETURNS INT
AS
    BEGIN
        DECLARE 
            @sum INT,
            @userId INT,
            @cosId INT;

        SET @sum = 0;

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

            SELECT @sum = SUM(p.price)
            FROM Products p, Cos_cumparaturi c, Item i
            WHERE c.cosId = i.cosId AND
                i.productId = p.productId AND
                i.cosId = @cosId;

        RETURN @sum;
    END
GO

--exec sum_products @userName="ana";