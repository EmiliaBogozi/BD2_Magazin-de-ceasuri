
CREATE OR ALTER TRIGGER update_connection
ON Users
AFTER UPDATE
AS
    DECLARE
        @userId INT,
        @userName NVARCHAR(50),
        @pass NVARCHAR(20),
        @email NVARCHAR(50),
        @telefon INT,
        @conectat INT,
        @actionPerformed NVARCHAR(50);

    SELECT 
        @userId = i.userId,
        @userName = i.userName,
        @pass = i.pass,
        @email = i.email,
        @telefon = i.telefon,
        @conectat = i.conectat
    FROM inserted i;

    IF (@conectat = 1)
    BEGIN
        SET @actionPerformed = 'Update conectat'
    END

    IF (@conectat = 0)
    BEGIN
        SET @actionPerformed = 'Update deconectat'
    END

    INSERT INTO Users_Audit (
        userId,
        userName,
        pass,
        email,
        telefon,
        conectat,
        updateTime,
        actionPerformed)
    VALUES (
        @userId,
        @userName,
        @pass,
        @email,
        @telefon,
        @conectat,
        GETDATE(),
        @actionPerformed
    )

    PRINT 'Utilizatorul ' + @userName + ' s-a conectat/deconectat cu succes';
GO

--exec connect_user @user_name = "ana";
--exec disconnect_user @user_name = "ana";
