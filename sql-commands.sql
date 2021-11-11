
-- Create New Database `ProjectDB`

	CREATE DATABASE ProjectDB;

-- Use Database `ProjectDB`

	USE ProjectDB;

-- Create Table named `Brand`

	CREATE TABLE Brand
	(BrandId int,
	BrandName varchar(200),
	BrandDesc varchar(max),
	BrandAddedDate datetime)

-- To retrieve data from `Brand` Table:

	SELECT * FROM Brand;

-- To insert data into `Brand` Table:

	INSERT INTO Brand VALUES(101, 'Adidas', 'Adidas Desc', '2021-11-01');
	INSERT INTO Brand VALUES(102, 'Puma', 'Puma Desc', GETDATE());
	INSERT INTO Brand VALUES(103, 'ZARA', 'ZARA Desc', NULL);
	INSERT INTO Brand(BrandId, BrandName, BrandDesc) VALUES(104, 'Pepe Jeans', 'Pepe Jeans Desc');

-- To update all records:

	UPDATE Brand
	SET BrandAddedDate = GETDATE();

-- To update specific record:

	UPDATE Brand
	SET BrandAddedDate = GETDATE()
	WHERE BrandId IN (103,104);

-- To delete specific record:

	DELETE FROM Brand
	WHERE BrandName = 'ZARA';

-- To delete all records:

	DELETE FROM Brand;

-- To drop `Brand` table:

	DROP TABLE Brand;

-- To create `Brand` Table with Constraints: 

	CREATE TABLE Brand
	(BrandId int primary key,
	BrandName varchar(200) not null,
	BrandDesc varchar(max),
	BrandAddedDate datetime default GETDATE())

-- To insert data into `Brand` Table:

	INSERT INTO Brand VALUES(101, 'Adidas', 'Adidas Desc', '2021-11-01');
	INSERT INTO Brand VALUES(102, 'Puma', 'Puma Desc', DEFAULT);
	INSERT INTO Brand VALUES(104, 'ZARA', 'ZARA Desc', DEFAULT);
	INSERT INTO Brand(BrandId, BrandName, BrandDesc) VALUES(103, 'Pepe Jeans', 'Pepe Jeans Desc');
	INSERT INTO Brand(BrandId, BrandName, BrandDesc) VALUES(105, 'MulMul', 'MulMul Desc');
	
	
-- To create `Product` Table with Constraints:

	CREATE TABLE Product
	(ProductId int primary key,
	ProductTag varchar(50) unique,
	ProductName varchar(200) not null,
	ProductPrice float check (ProductPrice > 1000),
	ProductQuantity int check (ProductQuantity > 0),
	ProductStatus varchar(200) check (ProductStatus IN ('New', 'Restocked')),
	ProductAddedDate datetime default GETDATE(), 
	BrandId int foreign key references Brand(BrandId));

-- To insert data into `Product` Table:

	INSERT INTO Product(ProductId, ProductTag, ProductName, ProductPrice, ProductQuantity, ProductStatus, BrandId)
	VALUES(5001, 'p001', 'Sports Shoes', 23000, 2, 'New', 101);
	INSERT INTO Product(ProductId, ProductTag, ProductName, ProductPrice, ProductQuantity, ProductStatus, BrandId)
	VALUES(5002, 'p002', 'Fancy Shoes', 1500, 2, 'New', 101);
	INSERT INTO Product(ProductId, ProductTag, ProductName, ProductPrice, ProductQuantity, ProductStatus, BrandId)
	VALUES(5003, 'p003', 'Sports Shoes', 23000, 8, 'Restocked', 102);
	INSERT INTO Product(ProductId, ProductTag, ProductName, ProductPrice, ProductQuantity, ProductStatus, BrandId)
	VALUES(5004, 'p004', 'Sports Shoes', 23000, 8, 'Restocked', 102);
	INSERT INTO Product(ProductId, ProductTag, ProductName, ProductPrice, ProductQuantity, ProductStatus, BrandId)
	VALUES(5005, 'p005', 'Ribbed Jeans', 12000, 3, 'New', 103);
	INSERT INTO Product(ProductId, ProductTag, ProductName, ProductPrice, ProductQuantity, ProductStatus, BrandId)
	VALUES(5006, 'p006', 'Casual WinterWear', 9000, 7, 'Restocked', 103);
	INSERT INTO Product(ProductId, ProductTag, ProductName, ProductPrice, ProductQuantity, ProductStatus, BrandId)
	VALUES(5007, 'p007', 'Woolean Jacket', 10000, 5, 'New', 104);
	INSERT INTO Product(ProductId, ProductTag, ProductName, ProductPrice, ProductQuantity, ProductStatus, BrandId)
	VALUES(5008, 'p008', 'Casual Shirt', 9000, 6, 'Restocked', 104);
	INSERT INTO Product(ProductId, ProductTag, ProductName, ProductPrice, ProductQuantity, ProductStatus, BrandId)
	VALUES(5009, 'p009', 'Winter Boot', 12000, 3, 'New', NULL);

-- Projection: To Restrict Columns

	SELECT ProductTag, ProductName, ProductPrice
	FROM Product;

-- Selection: To Restrict Rows

	SELECT * FROM Product
	WHERE ProductPrice > 10000;

-- Projection and Selection: Restrict Columns and Rows

	SELECT ProductTag, ProductName, ProductPrice
	FROM Product
	WHERE ProductPrice > 10000;

-- Arithmetic Operators (+, -, *, /)

	SELECT ProductTag, ProductName, ProductPrice, ProductPrice*0.10
	FROM Product
	WHERE ProductPrice > 10000;

	SELECT ProductTag, ProductName, ProductPrice, ProductPrice*0.10 as DiscountPrice
	FROM Product
	WHERE ProductPrice > 10000;
	
	SELECT ProductTag, ProductName, ProductPrice, ProductPrice*0.10 'Discount Price'
	FROM Product
	WHERE ProductPrice > 10000;

-- Conditional Operators (>, <, >=, <=, =, != )

	SELECT ProductTag, ProductName, ProductPrice
	FROM Product
	WHERE ProductPrice >= 10000;
	
	SELECT ProductTag, ProductName, ProductPrice
	FROM Product
	WHERE ProductPrice = 10000;

	SELECT ProductTag, ProductName, ProductPrice
	FROM Product
	WHERE ProductPrice != 10000;

-- Logical Operators (AND, OR, NOT)

	SELECT ProductTag, ProductName, ProductPrice
	FROM Product
	WHERE ProductTag = 'P001' AND ProductPrice = 23000

	SELECT ProductId, ProductTag, ProductName, ProductPrice
	FROM Product
	WHERE ProductId > 5005 AND ProductId < 5008

	SELECT ProductId, ProductTag, ProductName, ProductPrice
	FROM Product
	WHERE ProductName = 'Sports Shoes' OR ProductName = 'Fancy Shoes'

	SELECT ProductTag, ProductName, ProductPrice
	FROM Product
	WHERE ProductTag = 'P001' AND NOT ProductPrice = 20000

-- Misc Operators (BETWEEN, IN, IS NULL, LIKE)

	SELECT ProductId, ProductTag, ProductName, ProductPrice
	FROM Product
	WHERE ProductId BETWEEN 5005 AND 5008;

	SELECT ProductId, ProductTag, ProductName, ProductPrice
	FROM Product
	WHERE ProductId NOT BETWEEN 5005 AND 5008;

	SELECT ProductId, ProductTag, ProductName, ProductPrice
	FROM Product
	WHERE ProductName IN ('Sports Shoes','Fancy Shoes');

	SELECT ProductId, ProductTag, ProductName, ProductPrice
	FROM Product
	WHERE ProductName NOT IN ('Sports Shoes','Fancy Shoes');

	SELECT ProductId, ProductTag, ProductName, ProductPrice
	FROM Product
	WHERE ProductId NOT BETWEEN 5005 AND 5008
	AND ProductName NOT IN ('Sports Shoes','Fancy Shoes');

	SELECT * FROM Product
	WHERE BrandId IS NULL;

	SELECT * FROM Product
	WHERE BrandId IS NOT NULL;

	SELECT * FROM Product
	WHERE ProductName LIKE 'S%'

	SELECT * FROM Product
	WHERE ProductName LIKE '%r'

	SELECT * FROM Product
	WHERE ProductName LIKE '%J%'

	SELECT * FROM Product
	WHERE ProductName LIKE '_i%'

-- JOINS: To fetch records from two or more tables

	SELECT * FROM Brand;
	SELECT * FROM Product;

-- Fetch the Product Name and their respective Brand Name

	SELECT Product.ProductName, Brand.BrandName
	FROM Product JOIN Brand
	ON Product.BrandId = Brand.BrandId

	SELECT P.ProductName, b.BrandName
	FROM Product p JOIN Brand b
	ON p.BrandId = b.BrandId
	WHERE p.ProductPrice > 10000

	SELECT P.ProductName, b.BrandName, p.ProductPrice
	FROM Product p JOIN Brand b
	ON p.BrandId = b.BrandId
	AND p.ProductPrice > 10000








