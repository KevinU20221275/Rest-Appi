CREATE DATABASE ProductsAPI

USE ProductsAPI

CREATE TABLE Products
(
	Id INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	Name NVARCHAR(150),
	Price DECIMAL(12, 2)
)

CREATE PROCEDURE dbo.spProducts_GetAll
AS
BEGIN
	SELECT Id, Name, Price FROM Products;
END

CREATE PROCEDURE dbo.spProducts_GetById
@Id Int
AS
BEGIN
	SELECT Id, Name, Price FROM Products
	WHERE Id = @Id;
END

CREATE PROCEDURE dbo.spProducts_Insert
@Name NVARCHAR(150),
@Price DECIMAL(12, 2)
AS
BEGIN
	INSERT INTO Products
	VALUES(@Name, @Price)
END

CREATE PROCEDURE dbo.spProducts_Update
	@Name NVARCHAR(150),
	@Price DECIMAL(12, 2),
	@Id INT
AS
BEGIN
	UPDATE Products
	SET Name = @Name,
		Price = @Price
	WHERE Id = @Id
END

CREATE PROCEDURE dbo.spProducts_Delete
@Id INT
AS
BEGIN
	DELETE FROM Products 
	WHERE Id = @Id
END