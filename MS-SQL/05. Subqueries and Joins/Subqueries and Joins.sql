--01. Employee Address
USE [SoftUni];
GO

SELECT TOP(5) EmployeeID, JobTitle, a.AddressID, A.AddressText 
      FROM Employees 
	    AS e
      JOIN Addresses 
	    AS a 
		ON a.AddressID = e.AddressID
  ORDER BY AddressID

--02. Addresses with Towns
SELECT TOP(50) FirstName, LastName, t.[Name], a.AddressText
      FROM Employees 
	    AS e
	  JOIN Addresses
	    AS a
	    ON a.AddressID = e.AddressID
	  JOIN Towns
	    AS t
		ON t.TownID = a.TownID
  ORDER BY FirstName, LastName

--03. Sales Employees
SELECT EmployeeID, FirstName, LastName, d.[Name] 
  FROM Employees 
    AS e
  JOIN Departments 
    AS d
	ON d.DepartmentID = e.DepartmentID
 WHERE d.[Name] = 'Sales'

--04. Employee Departments
SELECT TOP(5) EmployeeID, FirstName, Salary, d.[Name]
      FROM Employees 
	    AS e
	  JOIN Departments 
	    AS d
		ON d.DepartmentID = e.DepartmentID
	 WHERE Salary > 15000
  ORDER BY d.DepartmentID

--05. Employees Without Projects
SELECT TOP(3) e.EmployeeID, e.FirstName
      FROM Employees
	    AS e
 LEFT JOIN EmployeesProjects 
	    AS ep
		ON ep.EmployeeID = e.EmployeeID
 LEFT JOIN Projects
	    AS p
		ON p.ProjectID = ep.ProjectID
	 WHERE ep.ProjectID IS NULL

--06. Employees Hired After
  SELECT FirstName, LastName, HireDate, d.[Name]
    FROM Employees 
      AS e
    JOIN Departments 
      AS d
	  ON d.DepartmentID = e.DepartmentID
   WHERE HireDate > '1-1-1999' AND d.Name = 'Sales' OR d.Name = 'Finance'
ORDER BY HireDate

--07. Employees With Project
SELECT TOP(5) e.EmployeeID, FirstName, p.[Name]
      FROM Employees 
	    AS e
      JOIN EmployeesProjects
        AS ep
		ON ep.EmployeeID = e.EmployeeID
      JOIN Projects
        AS p
		ON p.ProjectID = ep.ProjectID
	 WHERE P.StartDate > '2002-08-13' AND p.EndDate IS NULL
  ORDER BY e.EmployeeID

--08. Employee 24
SELECT e.EmployeeID, FirstName, 
  CASE
  WHEN p.StartDate >= '2005-01-01' THEN NULL 
  ELSE p.[Name]
   END 
    AS ProjectName
  FROM Employees e
  JOIN EmployeesProjects 
	AS ep 
	ON ep.EmployeeID = e.EmployeeID
  JOIN Projects 
	AS p 
	ON p.ProjectID = ep.ProjectID
 WHERE e.EmployeeID = 24
