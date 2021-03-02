
--Completarea unui Formular de Contact

CREATE OR ALTER PROCEDURE new_contact
    @nume NVARCHAR(20),
    @prenume NVARCHAR(20),
    @email NVARCHAR(50),
    @telefon INT,
    @mesaj NVARCHAR(1000)
AS
    INSERT INTO Contact(nume, prenume, email, telefon, mesaj)
    VALUES (@nume, @prenume, @email, @telefon, @mesaj)
GO
