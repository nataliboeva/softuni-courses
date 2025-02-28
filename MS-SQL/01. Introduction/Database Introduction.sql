--Problem 01
CREATE DATABASE [Minions]
GO

USE Minions;
GO

--Problem 02
CREATE TABLE Towns(
[Id] INT PRIMARY KEY,
[Name] NVARCHAR(50)
);

CREATE TABLE Minions(
[Id] INT PRIMARY KEY,
[Name] NVARCHAR(50),
[Age] INT
);

--Problem 03
ALTER TABLE [Minions] 
ADD [TownId] INT;

ALTER TABLE MINIONS
ADD CONSTRAINT FK_Minions_Towns
FOREIGN KEY (TownId) REFERENCES Towns(Id);

--Problem 04

INSERT INTO Towns([Id], [Name])
	 VALUES (1, 'Sofia'),
			(2, 'Plovdiv'),
			(3, 'Varna');

INSERT INTO Minions([Id], [Name], [Age], [TownId])
	 VALUES (1, 'Kevin', 22, 1),
			(2, 'Bob', 15, 3),
			(3, 'Steward', NULL, 2)
--Problem 05
TRUNCATE TABLE Minions

--Problem 06
DROP TABLE Minions

--Problem 07
CREATE TABLE [People](
[Id] INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(200) NOT NULL,
[Picture] VARBINARY(MAX) NULL,
[Height] DECIMAL (3,2) NULL,
[Weight] DECIMAL (5,2) NULL,
[Gender] CHAR(1) NOT NULL
CHECK ([Gender] = 'm' OR [Gender] = 'f'),
[Birthdate] DATETIME2 NOT NULL,
[Biography] NVARCHAR(MAX) NULL
);

INSERT INTO People([Name],[Height],[Weight],[Gender],[Birthdate])
	 VALUES ('George', 1.80, 78.22, 'm', '2002-09-12'),
			('Mary', 1.63, 50, 'f', '2005-03-30'),
			('Natalie', 1.68, 53.3, 'f', '2006-08-22'),
			('Stiliyan', 1.79, 72.8, 'm', '2005-11-27'),
			('Lucy', 1.66, 57, 'f', '2008-02-25');

--Problem 08
CREATE TABLE [Users](
[Id] INT PRIMARY KEY IDENTITY,
[Username] VARCHAR(30) NOT NULL UNIQUE,
[Password] VARCHAR(26) NOT NULL,
[ProfilePicture] VARBINARY NULL,
[LastLoginTime] DATETIME2,
[IsDeleted] VARCHAR(5) 
CHECK([IsDeleted] = 'true' OR [IsDeleted] = 'false')
)

INSERT INTO Users([Username],[Password],[LastLoginTime],[IsDeleted])
	 VALUES ('AdMiN123', 'admin123', '2025-01-10', 'false'),
			('User1234', 'user1234', '2024-12-31', 'true'),
			('Test', 'test123', '2025-02-02', 'false'),
			('Database', 'esabataD', '2022-06-14', 'true'),
			('Manager', 'HelloWorld', '2025-01-05', 'false');

--Problem 09
ALTER TABLE Users
DROP CONSTRAINT PK__Users__3214EC07E3CFA487;
GO

ALTER TABLE Users
ADD CONSTRAINT PK_UsernameID PRIMARY KEY (Username,Id);
GO
--Problem 10
ALTER TABLE Users
ADD CONSTRAINT CHK_Users_Password_Length
CHECK(LEN(Password) >= 5);
GO
--Problem 11
ALTER TABLE Users
ADD CONSTRAINT DF_Users_LastLoginTime
DEFAULT GETDATE() FOR LastLoginTime;
GO

--Problem 12
ALTER TABLE Users
DROP CONSTRAINT PK_UsernameID;
GO

ALTER TABLE Users
ADD CONSTRAINT PK_ID PRIMARY KEY (Id);
GO

ALTER TABLE Users
ADD CONSTRAINT CHK_Users_Username_Lenght
CHECK(LEN(Username) >= 3);
GO

--Problem 13
CREATE DATABASE [Movies]
GO

USE Movies;
GO

CREATE TABLE [Directors](
[Id] INT PRIMARY KEY IDENTITY,
[DirectorName] NVARCHAR(50) NOT NULL,
[Notes] NVARCHAR(255) NULL
);

CREATE TABLE [Genres](
[Id] INT PRIMARY KEY IDENTITY,
[GenreName] NVARCHAR(50) NOT NULL,
[Notes] NVARCHAR(255) NULL
);

CREATE TABLE [Categories](
[Id] INT PRIMARY KEY IDENTITY,
[CategoryName] NVARCHAR(50) NOT NULL,
[Notes] VARCHAR(255) NULL
);

CREATE TABLE [Movies](
[Id] INT PRIMARY KEY IDENTITY,
[Title] VARCHAR(50) NOT NULL,
[DirectorId]  INT FOREIGN KEY REFERENCES Directors(Id) NOT NULL,
[CopyrightYear] INT NULL,
[Length] DECIMAL(5,2) NULL,
[GenreId] INT FOREIGN KEY REFERENCES Genres(Id) NOT NULL,
[CategoryId] INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
[Rating] VARCHAR NULL,
[Notes] VARCHAR(255) NULL
);

INSERT INTO Directors(DirectorName, Notes)
	 VALUES ('Angelina Jolie', NULL),
			('Brad Pitt', NULL),
			('Vince Vaughn', NULL),
			('Simon Kinberg', NULL),
			('Adam Brody', NULL);

INSERT INTO Genres(GenreName, Notes)
	 VALUES ('Comedy', NULL),
			('Romantic', NULL),
			('Drama', NULL),
			('Crime', NULL),
			('Action', NULL);

INSERT INTO Categories(CategoryName, Notes)
	 VALUES
				('Fiction', NULL),
				('Non-Fiction', NULL),
				('Animated', NULL),
				('Documentary', NULL),
				('Short', NULL)

INSERT INTO Movies(Title, DirectorId, GenreId, CategoryId)
	 VALUES
				('The Shawshank Redemption', 2, 3, 1),
				('The Dark Knight', 1, 5, 1),
				('Pulp Fiction', 3, 4, 1),
				('Eternal Sunshine of the Spotless Mind', 4, 2, 1),
				('The Lord of the Rings: The Fellowship of the Ring', 5, 5, 1);

--Problem 14
CREATE DATABASE CarRental
GO

USE CarRental;
GO

CREATE TABLE Categories(
[Id] INT PRIMARY KEY IDENTITY,
[CategoryName] NVARCHAR(50) NOT NULL,
[DailyRate] DECIMAL (5,2) NULL,
[WeeklyRate] DECIMAL (5,2) NULL,
[MonthlyRate] DECIMAL (5,2) NULL,
)

CREATE TABLE Cars(
[Id] INT PRIMARY KEY,
[PlateNumber] VARCHAR(15) NOT NULL,
[Manufacturer] VARCHAR(50) NULL,
[Model] NVARCHAR(50) NOT NULL,
[CarYear] INT NULL,
[CategoryId] INT FOREIGN KEY REFERENCES Categories(Id),
[Doors] INT NULL,
[Picture] VARBINARY NULL,
[Condition] NVARCHAR(50) NULL,
[Available] VARCHAR(5) NOT NULL
CHECK(Available = 'true' OR Available = 'false')
)

CREATE TABLE Employees(
[Id] INT PRIMARY KEY,
[FirstName] NVARCHAR(50) NOT NULL,
[LastName] NVARCHAR(50) NOT NULL,
[Title] NVARCHAR(50) NULL,
[Notes] NVARCHAR(255) NULL
)

CREATE TABLE Customers(
[Id] INT PRIMARY KEY,
[DriverLicenseNumber] VARCHAR(20) NOT NULL,
[FullName] NVARCHAR(255) NOT NULL,
[Address] NVARCHAR(50) NOT NULL,
[City] NVARCHAR(36) NOT NULL,
[ZIPCode] INT NULL,
[Notes] NVARCHAR(255) NULL
)

CREATE TABLE RentalOrders(
[Id] INT PRIMARY KEY IDENTITY,
[EmployeeId] INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
[CustomerId] INT FOREIGN KEY REFERENCES Customers(Id) NOT NULL,
[CarId] INT FOREIGN KEY REFERENCES Cars(Id) NOT NULL,
[TankLevel] DECIMAL (3,2) NULL,
[KilometrageStart] INT NULL,
[KilometrageEnd] INT NULL,
[TotalKilometrage] INT NULL,
[StartDate] DATETIME2 NOT NULL,
[EndDate] DATETIME2 NOT NULL,
[TotalDays] INT NULL,
[RateApplied] INT NULL,
[TaxRate] DECIMAL (5,2) NULL,
[OrderStatus] VARCHAR(5) NOT NULL
CHECK([OrderStatus] = 'true' OR [OrderStatus] = 'false'),
[Notes] VARCHAR(255)
)

INSERT INTO Categories ([CategoryName], [DailyRate], [WeeklyRate], [MonthlyRate])
     VALUES ('Economy', 300.00, 180.00, 700.00),
            ('SUV', 500.00, 300.00, 920.00),
            ('Luxury', 100.00, 600.00, 980.00);

INSERT INTO Cars ([Id],[PlateNumber], [Manufacturer], [Model], [CarYear],
            [CategoryId], [Doors], [Condition], [Available])
     VALUES (1, 'ABC123', 'Toyota', 'Corolla', 2020, 1, 4, 'Good', 'true'),
            (2, 'XYZ789', 'Honda', 'CR-V', 2021, 2, 4, 'Excellent', 'true'),
            (3, 'LMN456', 'BMW', 'X5', 2019, 3, 4, 'Very Good', 'false');

INSERT INTO Employees ([Id], [FirstName],[LastName], [Title], [Notes])
     VALUES (1, 'John', 'Doe', 'Manager', 'Senior employee'),
            (2, 'Jane', 'Smith', 'Assistant', 'Works in customer service'),
            (3, 'Mike', 'Brown', 'Technician', 'Handles vehicle maintenance');


INSERT INTO Customers ([Id], [DriverLicenseNumber], [FullName],
            [Address], [City], [ZIPCode], [Notes])
     VALUES (1, 'DL123456', 'Alice Johnson', '123 Main St', 'Los Angeles', '90001', 'Regular customer'),
            (2, 'DL789012', 'Bob Williams', '456 Oak Ave', 'New York', '10001', NULL),
            (3, 'DL345678', 'Charlie Davis', '789 Pine Rd', 'Chicago', '60601', 'Prefers SUVs');

INSERT INTO RentalOrders ([EmployeeId], [CustomerId], [CarId], [TankLevel],
            [KilometrageStart], [KilometrageEnd], [TotalKilometrage], [StartDate],
			[EndDate], [TotalDays], [RateApplied], [TaxRate], [OrderStatus], [Notes])
     VALUES (1, 1, 1, 0.75, 15000, 15200, 200, '2024-02-01', '2024-02-05', 4, 30.00, 7.00, 'true', 'No issues'),
            (2, 2, 2, 0.60, 22000, 22500, 500, '2024-01-20', '2024-01-27', 7, 50.00, 8.00, 'true', NULL),
            (3, 3, 3, 0.90, 18000, 18250, 250, '2024-02-10', '2024-02-15', 5, 100.00, 10.00, 'false', 'Minor scratch');
