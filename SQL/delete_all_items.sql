
--Procedura pentru eliminarea tuturor produselor din cosul unui
--utilizator in cazul finalizarii comenzii

CREATE OR ALTER PROCEDURE delete_all_items
    @userName NVARCHAR(50)
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

    DELETE
    FROM Item 
    WHERE cosId = @cosId;
END
GO

--exec delete_all_items @userName = "ana";

