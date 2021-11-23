
USE ProjectDB;

CREATE TABLE Department
(DeptId INT PRIMARY KEY,
DeptName VARCHAR(MAX) NOT NULL,
DeptLocation VARCHAR(MAX) 
CHECK (DeptLocation IN ('Delhi', 'Mumbai', 'Chennai')),
DeptAddedDate DATETIME DEFAULT GETDATE())

CREATE TABLE Employee
(EmpId INT PRIMARY KEY,
EmpName VARCHAR(MAX) NOT NULL,
EmpSalary FLOAT CHECK (EmpSalary > 5000),
ManagerId INT FOREIGN KEY REFERENCES Employee(EmpId),
EmpAddedDate DATETIME DEFAULT GETDATE(),
DeptId INT FOREIGN KEY REFERENCES Department(DeptId))

	SELECT * FROM Department;
	SELECT * FROM Employee;

-- Inner join: Fetch Employee and their Department Name

	SELECT Employee.EmpName, Department.DeptName
	FROM Employee JOIN Department
	ON Employee.DeptId = Department.DeptId

	SELECT e.EmpName, d.DeptName
	FROM Employee e JOIN Department d
	ON e.DeptId = d.DeptId

-- Left Outer Join

	SELECT e.EmpName, e.EmpSalary, d.DeptName, d.DeptLocation
	FROM Employee e LEFT OUTER JOIN Department d
	ON e.DeptId = d.DeptId

-- Right Outer Join

	SELECT e.EmpName, e.EmpSalary, d.DeptName, d.DeptLocation
	FROM Employee e RIGHT OUTER JOIN Department d
	ON e.DeptId = d.DeptId

-- Full Outer Join

	SELECT e.EmpName, e.EmpSalary, d.DeptName, d.DeptLocation
	FROM Employee e FULL OUTER JOIN Department d
	ON e.DeptId = d.DeptId

-- Self Join

	SELECT emp.EmpName EmployeeName, mgr.EmpName ManagerName
	FROM Employee emp JOIN Employee mgr
	ON emp.ManagerId = mgr.EmpId

-- Cross Join
	
	SELECT e.EmpName, e.EmpSalary, d.DeptName, d.DeptLocation
	FROM Employee e CROSS JOIN Department d

-- Misc

	SELECT e.*, d.*
	FROM Employee e JOIN Department d
	ON e.DeptId = d.DeptId

	SELECT e.EmpName, e.EmpSalary, d.*
	FROM Employee e JOIN Department d
	ON e.DeptId = d.DeptId
	AND e.EmpSalary > 30000

	SELECT e.EmpName, e.EmpSalary, d.*
	FROM Employee e JOIN Department d
	ON e.DeptId = d.DeptId
	WHERE e.EmpSalary > 30000
	
-- Joining Two Tables without Join Keyword:

	SELECT e.EmpName, e.EmpSalary, d.DeptName, d.DeptLocation
	FROM Employee e, Department d
	WHERE e.DeptId = d.DeptId


	USE ProjectDB;
	
	SELECT * FROM Department;
	SELECT * FROM Employee;

-- Aggregate Functions

	SELECT SUM(EmpSalary) TotalSalary
	FROM Employee;

	SELECT MAX(EmpSalary) MaximumSalary
	FROM Employee;

	SELECT MIN(EmpSalary) MinimumSalary
	FROM Employee;

	SELECT AVG(EmpSalary) AverageSalary
	FROM Employee;

	SELECT COUNT(EmpSalary) TotalEmployees
	FROM Employee;

	SELECT SUM(EmpSalary) TotalSalary,
	MAX(EmpSalary) MaximumSalary,
	MIN(EmpSalary) MinimumSalary,
	AVG(EmpSalary) AverageSalary,
	COUNT(EmpSalary) TotalEmployees
	FROM Employee;

-- Single Row Function

	SELECT UPPER(EmpName)
	FROM Employee;

-- Multi Row Function (Aggregate Function)

	SELECT SUM(EmpSalary) TotalSalary,
	MAX(EmpSalary) MaximumSalary,
	MIN(EmpSalary) MinimumSalary,
	AVG(EmpSalary) AverageSalary,
	COUNT(EmpSalary) TotalEmployees
	FROM Employee;

-- Calculate the sum of salaries given to each department.

	SELECT DeptId, SUM(EmpSalary)
	FROM Employee
	GROUP BY DeptId

	SELECT DeptId,ManagerId, SUM(EmpSalary)
	FROM Employee
	GROUP BY DeptId, ManagerId

	SELECT DeptId, SUM(EmpSalary)
	FROM Employee
	WHERE DeptId = 102
	GROUP BY DeptId

	SELECT DeptId, SUM(EmpSalary)
	FROM Employee
	GROUP BY DeptId
	HAVING SUM(EmpSalary) > 50000