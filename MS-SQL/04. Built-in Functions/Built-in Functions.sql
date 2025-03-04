USE [SoftUni];
GO
--01. Find Names of All Employees by First Name
SELECT FirstName, LastName 
  FROM Employees
 WHERE FirstName LIKE 'Sa%'

--02. Find Names of All Employees by Last Name
 SELECT FirstName, LastName 
  FROM Employees
 WHERE LastName LIKE '%ei%'

--03. Find First Names of All Employees
 SELECT FirstName
   FROM Employees
  WHERE DepartmentID IN (3,10) AND YEAR(HireDate) BETWEEN 1995 AND 2005

--04. Find All Employees Except Engineers
 SELECT FirstName, LastName
   FROM Employees
  WHERE JobTitle NOT LIKE '%engineer%'

--05. Find Towns with Name Length
  SELECT [Name]
    FROM Towns
   WHERE LEN([Name]) = 5 OR LEN([Name]) = 6
ORDER BY [Name]

--06. Find Towns Starting With
  SELECT *
    FROM Towns
   WHERE [Name] LIKE '[MKBE]%'
ORDER BY [Name]

--07. Find Towns Not Starting With
  SELECT *
    FROM Towns
   WHERE [Name] NOT LIKE '[RBD]%'
ORDER BY [Name]

--08. Create View Employees Hired After 2000 Year
CREATE VIEW V_EmployeesHiredAfter2000
AS
SELECT FirstName, LastName
  FROM Employees
 WHERE YEAR(HireDate) > 2000

 --09. Length of Last Name
 SELECT FirstName, LastName
    FROM Employees
   WHERE LEN(LastName) = 5

--10. Rank Employees by Salary
  SELECT EmployeeID, FirstName, LastName, Salary, DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
    FROM Employees
   WHERE Salary BETWEEN 10000 AND 50000
ORDER BY Salary DESC

--11. Find All Employees with Rank 2
  SELECT * 
    FROM
			(SELECT EmployeeID, FirstName, LastName, Salary, DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
			   FROM Employees
		      WHERE Salary BETWEEN 10000 AND 50000)
		         AS [Subquery]
   WHERE Subquery.Rank = 2
ORDER BY Salary DESC

--12. Countries Holding 'A' 3 or More Times
USE [Geography];
GO

  SELECT CountryName AS [Country Name], IsoCode AS [ISO Code] 
    FROM Countries
   WHERE CountryName LIKE '%A%%A%%A%'
ORDER BY IsoCode

--13. Mix of Peak and River Names
  SELECT p.PeakName, r.RiverName,
   LOWER(LEFT(p.PeakName, LEN(p.PeakName) - 1) + r.RiverName) AS Mix
    FROM Peaks AS p, Rivers AS r
   WHERE RIGHT(p.PeakName, 1) = LEFT(r.RiverName, 1)
ORDER BY Mix

--14. Games From 2011 and 2012 Year
USE [Diablo];
GO

  SELECT TOP(50) [Name], FORMAT([Start], 'yyyy-MM-dd') AS [Start]
    FROM Games
   WHERE YEAR([Start]) BETWEEN 2011 AND 2012
ORDER BY [Start], [Name]

--15. User Email Providers
  SELECT Username, SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email)) AS [Email Provider]
    FROM Users
ORDER BY [Email Provider], Username

--16. Get Users with IP Address Like Pattern
  SELECT Username, IpAddress
    FROM Users
   WHERE IpAddress LIKE '___.1%.%.___'
ORDER BY Username

--17. Show All Games with Duration & Part of the Day
SELECT [Name] AS Game,
  CASE
  WHEN DATEPART(HOUR, [Start]) >= 0 AND DATEPART(HOUR, [Start]) < 12 THEN 'Morning'
  WHEN DATEPART(HOUR, [Start]) >= 12 AND DATEPART(HOUR, [Start]) < 18 THEN 'Afternoon'
  WHEN DATEPART(HOUR, [Start]) >= 18 AND DATEPART(HOUR, [Start]) < 24 THEN 'Evening'
   END 
    AS [Part of the Day],
  CASE
  WHEN Duration IS NULL THEN 'Extra Long'
  WHEN Duration <= 3 THEN 'Extra Short'
  WHEN Duration BETWEEN 4 AND 6 THEN 'Short'
  WHEN Duration > 6 THEN 'Long'
   END 
    AS [Duration]
  FROM Games
ORDER BY [Name], [Duration], [Part of the Day]

--18. Orders Table
USE[Orders];
GO
SELECT ProductName, OrderDate, DATEADD(DAY, 3, OrderDate) AS [Pay Due], DATEADD(MONTH, 1, OrderDate) AS [Deliver Due]
  FROM Orders
