USE SoftUni;
GO
--problem 01
CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000
			  AS
		   BEGIN
		  SELECT FirstName, LastName
		    FROM Employees
		   WHERE Salary > 35000
			 END
--problem 02
CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber @minSalary DECIMAL (18,4)
			  AS
		   BEGIN
		  SELECT FirstName, LastName
		    FROM Employees
		   WHERE Salary >= @minSalary
			 END

--problem 03
CREATE PROCEDURE usp_GetTownsStartingWith @city VARCHAR(20)
			  AS
		   BEGIN
		  SELECT [Name]
		    FROM Towns
		   WHERE [Name] LIKE @city + '%'
		     END
--problem 04
CREATE PROCEDURE usp_GetEmployeesFromTown @town VARCHAR(30)
			  AS
		   BEGIN
		  SELECT FirstName, LastName
		    FROM Employees AS e
	   LEFT JOIN Addresses AS a
	          ON e.AddressID = a.AddressID
	   LEFT JOIN Towns AS t
	          ON a.TownID = t.TownID
		   WHERE t.Name = @town
		     END
--problem 05
CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4)) 
        RETURNS VARCHAR(10)
             AS
		  BEGIN
		DECLARE @salaryLevel VARCHAR(10)
		     IF (@salary < 30000) SET @salaryLevel = 'Low'
		ELSE IF (@salary BETWEEN 30000 AND 50000) SET @salaryLevel = 'Average'
		   ELSE SET @salaryLevel = 'High'
		 RETURN @salaryLevel
		    END
--problem 06
CREATE PROCEDURE usp_EmployeesBySalaryLevel @salaryLevel VARCHAR(10)
              AS
		   BEGIN
		  SELECT FirstName AS [First Name],
				 LastName AS [Last Name]
		    FROM Employees
		   WHERE [dbo].[ufn_GetSalaryLevel](Salary) = @salaryLevel
		     END
--problem 07
CREATE FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(30), @word NVARCHAR(30))
RETURNS BIT
AS
BEGIN
		DECLARE @i INT = 1
		
		WHILE @i <= LEN(@word)
		BEGIN
				DECLARE @char NVARCHAR(1) = SUBSTRING(@word, @i, 1)
				IF CHARINDEX(@char, @setOfLetters) = 0
					RETURN 0
				ELSE
					SET @i += 1
		  END
		  RETURN 1
END