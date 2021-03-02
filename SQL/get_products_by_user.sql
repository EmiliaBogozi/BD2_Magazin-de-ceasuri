CREATE OR ALTER PROCEDURE get_products_by_user
    @userName NVARCHAR(50)
AS
    SELECT p.productId, p.productName, p.brand, p.color, p.price, c.cosId
    FROM Products p, Item i, Cos_cumparaturi c, Users u
    WHERE @userName = u.userName AND 
        c.userId = u.userId AND
        p.productId = i.productId AND
        i.cosId = c.cosId;
GO

--exec get_products_by_user @userName = "ana";