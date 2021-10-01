CREATE DATABASE [Shop]
GO

USE [Shop];
GO

CREATE TABLE [dbo].[Categories]
(
	[ID] INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	[Name] NVARCHAR(100) NOT NULL
);
GO

CREATE TABLE [dbo].[Products]
(
	[ID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] NVARCHAR(100) NOT NULL,
	[Price] INT NOT NULL,
	[CategoryId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Categories]([ID])
);
GO

CREATE PROCEDURE fillTables AS
DECLARE @i SMALLINT,
		@j SMALLINT

SET		@i = 1

	WHILE (@i <= 100)
		BEGIN
			INSERT INTO [dbo].[Categories](name)
			VALUES (CONCAT('Category', @i));

			SET @i = @i + 1;
		END 

SET		@j = 1
	WHILE (@j <= 1000)
		BEGIN
			INSERT INTO [dbo].[Products](name, price, CategoryId)
			VALUES	(CONCAT('Product', @j),
					(FLOOR(35 + RAND() * 149)),
					(FLOOR(1 + RAND() * 100)));

			SET @j = @j + 1;
		END

	SELECT * FROM [dbo].[Products]
GO

EXEC fillTables;
