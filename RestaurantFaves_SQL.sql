--CREATE DATABASE OrdersDB;
--USE OrdersDB;

--CREATE TABLE [Order] (
--	Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
--	[Description] NVARCHAR(255),
--	Restaurant NVARCHAR(255),
--	Rating INT,
--	OrderAgain BIT
--);

--INSERT INTO [Order] ([Description], Restaurant, Rating, OrderAgain)
--VALUES ('Fillet Mignon', 'Fancy Steakhouse', 5, 1),
--('Buffalo Mac and Cheese', 'Mac and Cheesery', 4, 1),
--('Onion Salad', 'No Fun Allowed', 1, 0);

SELECT * FROM [Order];