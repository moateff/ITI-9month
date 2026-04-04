USE SD;

-- 1. Create the following tables with all the required information and load the required data 
--	  as specified in each table using insert statements[at least two rows]

CREATE RULE r1 AS @x IN ('NY', 'DS', 'KW');
CREATE DEFAULT def1 AS 'NY';
SP_ADDTYPE loc, 'NCHAR(2)', 'NOT NULL';
SP_BINDRULE r1, loc;
SP_BINDEFAULT def1, loc;

CREATE TABLE Department
(
	DeptNo CHAR(2) PRIMARY KEY,
	DeptName VARCHAR(50),
	Location loc
);

INSERT INTO Department (DeptNo, DeptName, Location)
VALUES
('d1', 'Research',   'NY'),
('d2', 'Accounting', 'DS'),
('d3', 'Markiting',  'KW');

CREATE TABLE Employee
(
    EmpNo INT,
    EmpFname VARCHAR(30) NOT NULL,
    EmpLname VARCHAR(30) NOT NULL,
    DeptNo CHAR(2),
    Salary INT,

    CONSTRAINT PK_Employee PRIMARY KEY (EmpNo),
    CONSTRAINT UQ_Employee_Salary UNIQUE (Salary),
    CONSTRAINT FK_Employee_Department
        FOREIGN KEY (DeptNo)
        REFERENCES Department(DeptNo)
);

CREATE RULE r2 AS @x < 6000;
SP_BINDRULE r2, 'Employee.Salary';

INSERT INTO Employee VALUES
(25348, 'Mathew', 'Smith',     'd3', 2500),
(10102, 'Ann',    'Jones',     'd3', 3000),
(18316, 'John',   'Barrimore', 'd1', 2400),
(29346, 'James',  'James',     'd2', 2800),
(9031,  'Lisa',   'Bertoni',   'd2', 4000),
(2581,  'Elisa',  'Hansel',    'd2', 3600),
(28559, 'Sybl',   'Moser',     'd1', 2900);

INSERT INTO Project (ProjectNo, ProjectName, Budget)
VALUES
('p1', 'Apollo',  120000),
('p2', 'Gemini',   95000),
('p3', 'Mercury', 185600);

INSERT INTO Works_on (EmpNo, ProjectNo, Job, Enter_Date)
VALUES
(10102, 'p1', 'Analyst', '2006-10-01'),
(10102, 'p3', 'Manager', '2012-01-01'),
(25348, 'p2', 'Clerk',   '2007-02-15'),
(18316, 'p2', NULL,      '2007-06-01'),
(29346, 'p2', NULL,      '2006-12-15'),
(2581,  'p3', 'Analyst', '2007-10-15'),
(9031,  'p1', 'Manager', '2007-04-15'),
(28559, 'p1', NULL,      '2007-08-01'),
(28559, 'p2', 'Clerk',   '2012-02-01'),
(9031,  'p3', 'Clerk',   '2006-11-15'),
(29346, 'p1', 'Clerk',   '2007-01-04');

-- Testing Referential Integrity
-- 1- Add new employee with EmpNo =11111 In the works_on table [what will happen]
INSERT INTO Works_on VALUES (11111, 'p1', 'Analyst', '2024-01-01'); 
-- The INSERT statement conflicted with the FOREIGN KEY constraint "FK_Works_on_Employee". 
-- The conflict occurred in database "SD", table "dbo.Employee", column 'EmpNo'.

-- 2- Change the employee number 10102  to 11111  in the works on table [what will happen]
UPDATE Works_On
SET EmpNo = 11111
WHERE EmpNo = 10102;
-- The UPDATE statement conflicted with the FOREIGN KEY constraint "FK_Works_on_Employee". 
-- The conflict occurred in database "SD", table "dbo.Employee", column 'EmpNo'.

-- 3- Modify the employee number 10102 in the employee table to 22222. [what will happen]
UPDATE Employee
SET EmpNo = 22222
WHERE EmpNo = 10102;
-- The UPDATE statement conflicted with the REFERENCE constraint "FK_Works_on_Employee". 
-- The conflict occurred in database "SD", table "dbo.Works_on", column 'EmpNo'.

-- 4- Delete the employee with id 10102
DELETE FROM Employee WHERE EmpNo = 10102;
-- The DELETE statement conflicted with the REFERENCE constraint "FK_Works_on_Employee". 
-- The conflict occurred in database "SD", table "dbo.Works_on", column 'EmpNo'.

-- Table modification
-- 1. Add  TelephoneNumber column to the employee table
ALTER TABLE Employee
ADD TelephoneNumber VARCHAR(15);

-- 2. drop this column
ALTER TABLE Employee
DROP COLUMN TelephoneNumber;

-- 2. Create the following schema and transfer the following tables to it 
-- a. Company Schema 
--      i. Department table (Programmatically)
--      ii. Project table (using wizard)
CREATE SCHEMA Company;
ALTER SCHEMA Company TRANSFER Department;

-- b. Human Resource Schema
--      i. Employee table (Programmatically)
CREATE SCHEMA [Human Resource];
ALTER SCHEMA [Human Resource] TRANSFER Employee;

-- 3. Write query to display the constraints for the Employee table
SELECT 
    CONSTRAINT_NAME,
    CONSTRAINT_TYPE
FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS
WHERE TABLE_SCHEMA = [Human Resource]
  AND TABLE_NAME = 'Employee';


-- 4. Create Synonym for table Employee as Emp and then run the following queries and describe the results
CREATE SYNONYM Emp FOR [Human Resource].Employee;

Select * from Employee
-- Invalid object name 'Employee'.

Select * from [Human Resource].Employee
-- works 

Select * from Emp
-- works 

Select * from [Human Resource].Emp
-- Invalid object name 'Human Resource.Emp'.

-- 5. Increase the budget of the project where the manager number is 10102 by 10%.
UPDATE P
SET P.Budget = P.Budget * 1.10
FROM Company.Project AS P
INNER JOIN dbo.Works_On AS W
    ON P.ProjectNo = W.ProjectNo
WHERE W.EmpNo = 10102
    AND W.Job = 'Manager';

-- 6. Change the name of the department for which the employee named James works.The new department name is Sales.
UPDATE D
SET D.DeptName = 'Sales'
FROM Company.Department AS D
INNER JOIN [Human Resource].Employee AS E
    ON D.DeptNo = E.DeptNo
WHERE E.EmpFname = 'James';

-- 7. Change the enter date for the projects for those employees who work in project p1 and belong to department ‘Sales’. The new date is 12.12.2007.
UPDATE W
SET W.Enter_Date = '2007-12-12'
FROM dbo.Works_on AS W
INNER JOIN [Human Resource].Employee AS E
    ON W.EmpNo = E.EmpNo
INNER JOIN Company.Department AS D
    ON E.DeptNo = D.DeptNo
WHERE W.ProjectNo = 'p1'
AND D.DeptName = 'Sales';

-- 8. Delete the information in the works_on table for all employees who work for the department located in KW.
DELETE W
FROM dbo.Works_On AS W
INNER JOIN [Human Resource].Employee AS E
    ON W.EmpNo = E.EmpNo
INNER JOIN Company.Department AS D
    ON E.DeptNo = D.DeptNo
WHERE D.Location = 'KW';

-- 9. Try to Create Login Named(ITIStud) who can access Only student and Course tablesfrom ITI DB 
--    then allow him to select and insert data into tables and deny Delete and update .(Use ITI DB)
USE ITI;

CREATE LOGIN ITIStud WITH PASSWORD = '123';
CREATE USER ITIStud FOR LOGIN ITIStud;

GRANT SELECT, INSERT ON ITI.dbo.Student TO ITIStud;
GRANT SELECT, INSERT ON ITI.dbo.Course TO ITIStud;

DENY UPDATE, DELETE ON ITI.dbo.Student TO ITIStud;
DENY UPDATE, DELETE ON ITI.dbo.Course TO ITIStud;