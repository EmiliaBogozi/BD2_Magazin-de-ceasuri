CREATE OR ALTER PROCEDURE select_products
AS
    SELECT productId, productName, brand, color, price
    FROM Products;
GO