
CREATE OR ALTER TRIGGER update_shopping_cart
ON Item
AFTER INSERT, DELETE
AS
BEGIN
    DECLARE
        @userId INT,
        @cosId INT,
        @productId INT,
        @userName NVARCHAR(50),
        @productName NVARCHAR(100),
        @price INT,
        @color NVARCHAR(20),
        @brand NVARCHAR(40),
        @gender NVARCHAR(10),
        @actionPerformed NVARCHAR(50);

    If EXISTS (SELECT * from inserted) AND NOT EXISTS(SELECT * FROM deleted)
    BEGIN
        SET @actionPerformed = 'Insert';

        SELECT 
            @userId = u.userId, 
            @userName = u.userName
        FROM Users u, Cos_cumparaturi c, inserted i
        WHERE i.cosId = c.cosId AND 
            u.userId = c.userId;

        SELECT 
            @cosId = i.cosId,
            @productId = i.productId
        FROM inserted i;
    END

    If EXISTS (SELECT * from deleted) AND NOT EXISTS(SELECT * FROM inserted)
    BEGIN
        SET @actionPerformed = 'Delete';

        SELECT 
            @userId = u.userId, 
            @userName = u.userName
        FROM Users u, Cos_cumparaturi c, deleted d
        WHERE d.cosId = c.cosId AND 
            u.userId = c.userId;

        SELECT 
            @cosId = d.cosId,
            @productId = d.productId
        FROM deleted d;
    END

    SELECT 
        @productName = p.productName,
        @price = p.price,
        @color = p.color,
        @brand = p.brand,
        @gender = p.gender
    FROM Products p
    WHERE p.productId = @productId;

    

    INSERT INTO Cos_Audit (
        userId,
        cosId,
        productId,
        userName,
        productName,
        price,
        color,
        brand,
        gender,
        iddateTime,
        actionPerformed
    )
    VALUES (
        @userId,
        @cosId,
        @productId,
        @userName,
        @productName,
        @price,
        @color,
        @brand,
        @gender,
        GETDATE(),
        @actionPerformed
    )
END

--exec insert_item @userName = "ana", @productId = 5;
--exec disconnect_user @user_name = "ana";
