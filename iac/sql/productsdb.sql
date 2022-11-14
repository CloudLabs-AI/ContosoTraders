use productsdb

DROP TABLE IF EXISTS Brands

CREATE TABLE Brands
(
    Id int NOT NULL,
    Name nvarchar(255) NULL,
    CONSTRAINT PK_Brands PRIMARY KEY(Id)
)

INSERT INTO Brands
VALUES
    (1, 'Microsoft'),
    (2, 'ASUS'),
    (3, 'Dell'),
    (4, 'Acer')

DROP TABLE IF EXISTS Features

CREATE TABLE Features
(
    Id int NOT NULL,
    Title nvarchar(255) NULL,
    Description nvarchar(max) NULL,
    ProductItemId int NULL,
    CONSTRAINT PK_Features PRIMARY KEY(Id)
)

INSERT INTO Features
Values
    (1,'Model Number','Model Number: Xbox Series X',1),
    (2,'Additional Content','Additional Content: Series X console, One Wireless Controller, A high-speed HDMI Cable and Power Cable.',1),
    (3,'Model Number','Model Number: Xbox Series X',2),
    (4,'Additional Content','Additional Content: Series X console, One Wireless Controller, A high-speed HDMI Cable and Power Cable.',2),
    (5,'Model Number','Model Number: Xbox Series X',3),
    (6,'Additional Content','Additional Content: Series X console, One Wireless Controller, A high-speed HDMI Cable and Power Cable.',3),
    (7,'Model Number','Model Number: Xbox Series X',4),
    (8,'Additional Content','Additional Content: Series X console, One Wireless Controller, A high-speed HDMI Cable and Power Cable.',4),
    (9,'Model Number','Model Number: Xbox Series X',5),
    (10,'Additional Content','Additional Content: Series X console, One Wireless Controller, A high-speed HDMI Cable and Power Cable.',5),
    (11,'Series','Series : Surface Pro 7',6),
    (12,'Specifications','Specifications : Touchscreen 2-in-1 Laptop (10th Gen Intel Core i5/8GB/256GB SSD/Windows 10 Home/Intel Iris Plus Graphics, 25% Off on Microsoft 365), Black',6),
    (13,'Series','Series : Surface Pro 7',7),
    (14,'Specifications','Specifications : Touchscreen Laptop (8GB/256GB SSD/Windows 11 Home /Radeon Graphics/Platinum/1.265 kg) - 5PB-00023',7),

  

DROP TABLE IF EXISTS Tags

CREATE TABLE Tags
(
    Id int NOT NULL,
    Value nvarchar(255) NULL,
    CONSTRAINT PK_Tags PRIMARY KEY(Id)
)

INSERT INTO Tags
VALUES
    (1, 'RechargeableScrewdriver'),
    (2, 'Multitool'),
    (3, 'HardHat')

DROP TABLE IF EXISTS Types

CREATE TABLE Types
(
    Id int NOT NULL,
    Code nvarchar(255) NULL,
    Name nvarchar(255) NULL,
    CONSTRAINT PK_Types PRIMARY KEY(Id)
)

INSERT INTO Types
VALUES
    (1, 'controllers' , 'Controllers'),
    (2, 'laptops' , 'Laptops'),
    (3, 'desktops' , 'Desktops'),
    (4, 'mobiles' , 'Mobiles')  

DROP TABLE IF EXISTS Products

CREATE TABLE Products
(
    Id int NOT NULL,
    Name nvarchar(255) NULL,
    Price decimal(9, 2) NULL,
    ImageName nvarchar(255) NULL,
    BrandId int NULL,
    TypeId int NULL,
    TagId int NULL,
    CONSTRAINT PK_Products PRIMARY KEY(Id)
)

INSERT INTO Products (Id,Name,Price,ImageName,BrandId,TypeId,TagId)
VALUES
    (1,'Xbox Wireless Controller Lunar Shift Special Edition',99,'PID1-1.jpg',1,1,NULL),
    (2,'Xbox Wireless Controller Mineral Camo Special Edition',112,'PID2-1.jpg',1,1,NULL),
    (3,'Xbox Elite Wireless Controller Series 2 Core (White)',139,'PID3-1.jpg',1,1,NULL),
    (4,'Xbox Wireless Controller 20th Anniversary Special Edition',89,'PID4-1.jpg',1,1,NULL),
    (5,'Xbox Elite Wireless Controller Series 2 Halo Infinite Limited Edition',139,'PID5-1.jpg',1,1,NULL),
    (6,'Microsoft Surface Pro 7 PUV-00028 12.3" Black',249,'PID6-1.jpg',1,2,NULL),
    (7,'Xbox Elite Wireless Controller Series 2 Halo Infinite Limited Edition',299,'PID7-1.jpg',1,1,NULL)
 