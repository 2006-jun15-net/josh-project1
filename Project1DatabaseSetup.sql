CREATE TABLE Product 
(
	productId int PRIMARY KEY IDENTITY,
	productDescription nvarchar(25) NOT NULL,
	productPrice decimal NULL
);

CREATE TABLE Customer 
(
	customerId int PRIMARY KEY IDENTITY,
	firstName nvarchar(25) NOT NULL,
	lastName nvarchar(30) NOT NULL,
	userName nvarchar(50) NOT NULL UNIQUE
);

CREATE TABLE Store
(
	storeId int PRIMARY KEY IDENTITY,
	storeName nvarchar(30) NOT NULL,
	storeAddress nvarchar(50) UNIQUE NULL
);

CREATE TABLE Orders 
(
	orderId int PRIMARY KEY IDENTITY,
	orderDate DATETIME NOT NULL
);

CREATE TABLE StoreInventory 
(
	storeInvId int PRIMARY KEY IDENTITY,
	storeId int NOT NULL,
	productId int NOT NULL,
	quantity int NOT NULL,
	CONSTRAINT FK_STORE FOREIGN KEY (storeId) References Store(storeId),
	CONSTRAINT FK_PRODUCT FOREIGN KEY (productId) References Product(productId)
);



CREATE TABLE OrderHistory (
	orderHistId int PRIMARY KEY IDENTITY,
	storeId int NOT NULL,
	customerId int NOT NULL,
	orderId int NOT NULL,
	productId int NOT NULL,
	quantity int NOT NULL,
	CONSTRAINT FK_STORE_ID FOREIGN KEY (storeId) References Store(storeId),
	CONSTRAINT FK_CUSTOMER_ID FOREIGN KEY (customerId) References Customer(customerId),
	CONSTRAINT FK_ORDER_ID FOREIGN KEY (orderId) References Orders(orderId),
	CONSTRAINT FK_PRODUCT_ID FOREIGN KEY (productId) References Product(productId)
);


--Sample Data
-- INSERT INTO Product (productDescription, productPrice) VALUES (
-- 	('Pencil', 0.50),
-- 	('Eraser', 0.75),
-- 	('Laptop', 599.00),
-- 	('Charging Cable', 75.00),
-- 	('Software', 139.99)	
-- );