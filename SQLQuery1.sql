-- Create the database
CREATE DATABASE Ecommerce;
GO

-- Use the database
USE Ecommerce;
GO

-- Create the Cart table
CREATE TABLE Cart (
    Id INT PRIMARY KEY,
    Image NVARCHAR(MAX),
    Price DECIMAL(10, 2),
    Title NVARCHAR(MAX),
    Quantity INT  -- Added a comma and fixed this line
);
GO

-- Create procedure to add an item to the cart
CREATE PROCEDURE AddItem
    @Id INT,
    @Title NVARCHAR(MAX),
    @Image NVARCHAR(MAX),
    @Price DECIMAL(10, 2),
    @Quantity INT  -- Added a comma and fixed this line
AS
BEGIN
    INSERT INTO Cart (Id, Title, Image, Price, Quantity)
    VALUES (@Id, @Title, @Image, @Price, @Quantity);
END;
GO

-- Create procedure to delete an item from the cart by Id
CREATE PROCEDURE DeleteItem
    @Id INT
AS
BEGIN
    DELETE FROM Cart WHERE Id = @Id;
END;
GO

-- Create procedure to get all products in the cart
CREATE PROCEDURE GetProducts
AS
BEGIN
    SELECT Id, Title, Image, Price, Quantity FROM Cart;
END;
GO

-- Select all items from the Cart table
SELECT * FROM Cart;
GO
Drop Procedure [GetProducts];
Drop table Cart;