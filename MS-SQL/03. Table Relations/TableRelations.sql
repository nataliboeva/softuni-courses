CREATE DATABASE [TableRelations]
GO
USE [TableRelations]
GO

--01. One-To-One Relationship
CREATE TABLE Passports(
[PassportID] INT PRIMARY KEY,
[PassportNumber] VARCHAR(8)
)

CREATE TABLE Persons(
[PersonID] INT PRIMARY KEY IDENTITY,
[FirstName] VARCHAR(50),
[Salary] DECIMAL,
[PassportID] INT FOREIGN KEY REFERENCES Passports(PassportID)
)

INSERT INTO Passports (PassportID,PassportNumber)
     VALUES (101, 'N34FG21B'),
			(102, 'K65LO4R7'),
			(103, 'ZE657QP2')

INSERT INTO Persons ([FirstName], Salary, PassportID)
     VALUES ('Roberto', 43300.00, 102),
			('Tom', 56100.00, 103),
			('Yana', 60200.00, 101)


--02. One-To-Many Relationship
CREATE TABLE Manufacturers(
[ManufacturerID] INT PRIMARY KEY,
[Name] VARCHAR(50),
[EstablishedOn] DATETIME2,
)

CREATE TABLE Models(
[ModelID] INT PRIMARY KEY,
[Name] VARCHAR(50),
[ManufacturerID] INT FOREIGN KEY REFERENCES Manufacturers(ManufacturerID)
)

INSERT INTO Manufacturers([ManufacturerID],[Name], [EstablishedOn])
     VALUES (1, 'BMW', '07-03-1916'),
			(2, 'Tesla', '01-01-2003'),
			(3, 'Lada', '01-05-1966');

INSERT INTO Models([ModelID], [Name], [ManufacturerID])
     VALUES (101, 'X1', 1),
			(102, 'i6', 1),
			(103, 'Model S', 2),
			(104, 'Model X', 2),
			(105, 'Model 3', 2),
			(106, 'Nova', 3);

--03. Many-To-Many Relationship
CREATE TABLE Students(
[StudentID] INT PRIMARY KEY,
[Name] VARCHAR(50)
);

CREATE TABLE Exams(
[ExamID] INT PRIMARY KEY,
[Name] VARCHAR(50)
);

CREATE TABLE StudentsExams(
PRIMARY KEY (StudentID, ExamID),
[StudentID] INT FOREIGN KEY REFERENCES Students([StudentID]),
[ExamID] INT FOREIGN KEY REFERENCES Exams([ExamID])
)

INSERT INTO Students([StudentID],[Name])
     VALUES (1, 'Mila'),
			(2, 'Toni'),
			(3, 'Ron');

INSERT INTO Exams([ExamID], [Name])
     VALUES (101, 'SpringMVC'),
		    (102, 'Neo4j'),
			(103, 'Oracle 11g');

INSERT INTO StudentsExams(StudentID,ExamID)
     VALUES (1,101),
			(1,102),
			(2, 101),
			(3, 103),
			(2, 102),
			(2, 103);

--04. Self-Referencing
CREATE TABLE Teachers (
	TeacherID INT PRIMARY KEY,
	[Name] VARCHAR(64),
	ManagerID INT FOREIGN KEY REFERENCES Teachers(TeacherID)
)

INSERT INTO Teachers (TeacherID, [Name])
	VALUES
		(101, 'John'),		
		(102, 'Maya'),		
		(103, 'Silvia'),
		(104, 'Ted'),		
		(105, 'Mark'),		
		(106, 'Greta')

--05. Online Store Database
CREATE TABLE Cities (
	CityID INT PRIMARY KEY,
	[Name] VARCHAR(128) NOT NULL
)

CREATE TABLE Customers (
	CustomerID INT PRIMARY KEY,
	[Name] VARCHAR(128) NOT NULL,
	Birthday DATETIME,
	CityID INT FOREIGN KEY REFERENCES Cities(CityID)
)

CREATE TABLE Orders (
	OrderID INT PRIMARY KEY,
	CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID)
)

CREATE TABLE ItemTypes (
	ItemTypeID INT PRIMARY KEY,
	[Name] VARCHAR(128) NOT NULL
)

CREATE TABLE Items (
	ItemID INT PRIMARY KEY,
	[Name] VARCHAR(128) NOT NULL,
	ItemTypeID INT FOREIGN KEY REFERENCES ItemTypes(ItemTypeID)
)

CREATE TABLE OrderItems (
	OrderID INT FOREIGN KEY REFERENCES Orders(OrderID),
	ItemID INT FOREIGN KEY REFERENCES Items(ItemID),
	CONSTRAINT PK_OrderItems PRIMARY KEY(OrderId, ItemId)
)
--06. University Database
CREATE TABLE Majors (
	MajorID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(64) NOT NULL
)
CREATE TABLE Students (
	StudentID INT PRIMARY KEY IDENTITY,
	StudentNumber VARCHAR(64) NOT NULL,
	StudentName VARCHAR(128) NOT NULL,
	MajorID INT FOREIGN KEY REFERENCES Majors(MajorID)
)
CREATE TABLE Subjects (
	SubjectID INT PRIMARY KEY IDENTITY,
	SubjectName VARCHAR(64) NOT NULL
)
CREATE TABLE Agenda (
	StudentID INT FOREIGN KEY REFERENCES Students(StudentID),
	SubjectID INT FOREIGN KEY REFERENCES Subjects(SubjectID)
	CONSTRAINT PK_AGENDA PRIMARY KEY(StudentID, SubjectID)
)
CREATE TABLE Payments (
	PaymentID INT PRIMARY KEY IDENTITY,
	PaymentDate DATETIME NOT NULL,
	PaymentAmount DECIMAL(10,2) NOT NULL,
	StudentID INT FOREIGN KEY REFERENCES Students(StudentID)
)