DROP TABLE Item;
DROP TABLE Cos_cumparaturi;
DROP TABLE Contact;
DROP TABLE Products;
DROP TABLE Users;
DROP TABLE Users_Audit;
DROP TABLE Cos_Audit;

CREATE TABLE Users
(
    userId INT IDENTITY(1,1) PRIMARY KEY,
    userName NVARCHAR(50) NOT NULL UNIQUE,
    pass NVARCHAR(20) NOT NULL,
    email NVARCHAR(50),
    telefon INT,
    conectat INT
);

CREATE TABLE Products
(
    productId INT IDENTITY(1,1) PRIMARY KEY,
    productName NVARCHAR(100) NOT NULL,
    price INT NOT NULL,
    color NVARCHAR(20),
    brand NVARCHAR(40),
    gender NVARCHAR(10) NOT NULL
);

CREATE TABLE Contact
(
    nume NVARCHAR(20) NOT NULL,
    prenume NVARCHAR(20) NOT NULL,
    email NVARCHAR(50) NOT NULL,
    telefon INT,
    mesaj NVARCHAR(1000) NOT NULL
);

CREATE TABLE Cos_cumparaturi
(
    cosId INT IDENTITY(1,1) PRIMARY KEY,
    userId INT NOT NULL FOREIGN KEY REFERENCES [Users](userId),
    odate DATE NOT NULL
);

CREATE TABLE Item 
(
    cosId INT NOT NULL FOREIGN KEY REFERENCES [Cos_cumparaturi](cosId),
    productId INT NOT NULL FOREIGN KEY REFERENCES Products(productId)
);

CREATE TABLE Users_Audit(
    userId INT,
    userName NVARCHAR(50),
    pass NVARCHAR(20),
    email NVARCHAR(50),
    telefon INT,
    conectat INT,
    updateTime DATE,
    actionPerformed NVARCHAR(50)
);

CREATE TABLE Cos_Audit (
    userId INT,
    cosId INT,
    productId INT,
    userName NVARCHAR(50),
    productName NVARCHAR(100),
    price INT,
    color NVARCHAR(20),
    brand NVARCHAR(40),
    gender NVARCHAR(10),
    iddateTime DATE,
    actionPerformed NVARCHAR(50)
);


