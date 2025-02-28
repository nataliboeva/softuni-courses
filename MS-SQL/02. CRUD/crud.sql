--Problem 02
SELECT * FROM Departments

--Problem 03
SELECT [Name] 
  FROM Departments

--Problem 04
SELECT [FirstName], [LastName], [Salary] 
  FROM Employees

--Problem 05
SELECT [FirstName], [MiddleName], [LastName] 
  FROM Employees

--Problem 06
SELECT CONCAT (FirstName, '.', LastName, '@softuni.bg') 
           AS [Full Name Address] 
		 FROM Employees 

--Problem 07
SELECT DISTINCT Salary 
           FROM Employees

--Problem 08
SELECT * FROM Employees
        WHERE JobTitle = 'Sales Representative'

--Problem 09
SELECT FirstName, LastName, JobTitle
  FROM Employees
 WHERE Salary BETWEEN 20000 AND 30000

--Problem 10
SELECT CONCAT_WS (' ', FirstName, MiddleName, LastName) 
              AS [Full Name] 
		    FROM Employees
           WHERE Salary IN (25000, 14000, 12500, 23600)

 --Problem 11
SELECT FirstName,LastName
  FROM Employees
 WHERE ManagerID IS NULL

--Problem 12
  SELECT FirstName,LastName, Salary
	FROM Employees
   WHERE Salary > 50000
ORDER BY Salary DESC

--Problem 13
SELECT TOP(5) FirstName, LastName 
         FROM Employees
     ORDER BY Salary DESC

--Problem 14
SELECT FirstName, LastName 
  FROM Employees
 WHERE DepartmentID != 4

--Problem 15
SELECT * FROM Employees
     ORDER BY Salary DESC,
              FirstName ASC,
              LastName DESC,
              MiddleName ASC;
--Problem 16
CREATE VIEW [V_EmployeesSalaries] 
         AS
	 SELECT FirstName, LastName, Salary
	   FROM Employees;
 --Problem 17
 CREATE VIEW [V_EmployeeNameJobTitle]
          AS
	  SELECT FirstName + ' ' + ISNULL(MiddleName, '') + ' ' + LastName
	      AS [Full name], JobTitle
	    FROM Employees

--Problem 18
SELECT DISTINCT JobTitle 
           FROM Employees

--Problem 19
SELECT TOP (10) * 
      FROM Projects
  ORDER BY StartDate, Name

--Problem 20
SELECT TOP (7) FirstName, LastName, HireDate 
      FROM Employees
  ORDER BY HireDate DESC

--Problem 21
UPDATE Employees
   SET Salary += Salary * 0.12
 WHERE DepartmentID IN (1,2,4,11)

 SELECT Salary FROM Employees

 --Problem 22
 USE Geography; 
 GO
 SELECT [PeakName] FROM Peaks
 ORDER BY PeakName
 --Problem 23
 SELECT TOP (30) [CountryName], [Population] 
       FROM Countries
	  WHERE ContinentCode = 'EU'
   ORDER BY [Population] DESC,
            [CountryName]
--Problem 24
	SELECT [CountryName], [CountryCode],
	  CASE CurrencyCode
      WHEN 'EUR'
      THEN 'Euro'
      ELSE 'Not Euro'
    END AS 'Currency'
      FROM Countries
  ORDER BY CountryName;


--Problem 25
USE Diablo;
GO
SELECT [Name] FROM Characters
ORDER BY NAME;