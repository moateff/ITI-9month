USE Company_SD;
 
-- 1. Display the Department id, name and id and the name of its manager
SELECT d.Dnum, d.Dname, 
	   e.Fname + ' ' + e.Lname AS 'Full Name'
FROM Employee e INNER JOIN Departments d
ON e.SSN = d.MGRSSN;

-- 2. Display the name of the departments and the name of the projects under its control.
SELECT d.Dname AS 'Department Name', 
	   p.Pname AS 'Project Name'
FROM Project p INNER JOIN Departments d
ON p.Dnum = d.Dnum;

-- 3. Display the full data about all the dependence associated with 
--    the name of the employee they depend on him/her.
SELECT e.Fname + ' ' + e.Lname AS 'Full Name', d.*
FROM Employee e INNER JOIN Dependent d
ON e.SSN = d.ESSN;

-- 4. Display the Id, name and location of the projects in Cairo or Alex city.
SELECT p.Pnumber, p.Pname, p.Plocation
FROM Project p
WHERE p.City IN ('cairo', 'alex');

-- 5. Display the Projects full data of the projects with a name starts with "a" letter.
SELECT p.*
FROM Project p
WHERE p.Pname LIKE 'a%';

-- 6. display all the employees in department 30 whose salary from 1000 to 2000 LE monthly
SELECT e.*
FROM Employee e
WHERE e.Salary BETWEEN 1000 AND 2000 AND e.Dno = 30;

-- 7. Retrieve the names of all employees in department 10 who works more than or equal 10 hours per week on "AL Rabwah" project.
SELECT e.Fname + ' ' + e.Lname AS 'Full Name'
FROM Works_for w
INNER JOIN Employee e ON w.ESSn = e.SSN 
INNER JOIN Project p ON w.Pno = p.Pnumber
WHERE e.Dno = 10 AND p.Pname = 'AL Rabwah' AND w.Hours >= 10;

-- 8 Find the names of the employees who directly supervised with Kamel Mohamed.
SELECT e.Fname + ' ' + e.Lname AS 'Full Name'
FROM Employee e INNER JOIN Employee s ON e.Superssn = s.SSN 
where s.Fname = 'kamel' AND s.Lname = 'mohamed';

-- 9. Retrieve the names of all employees and the names of the projects they are working on, sorted by the project name.
SELECT e.Fname + ' ' + e.Lname AS 'Full Name', p.Pname
FROM Works_for w 
INNER JOIN Employee e ON w.ESSn = e.SSN
INNER JOIN Project p ON p.Pnumber = w.Pno
ORDER BY p.Pname;

-- 10. For each project located in Cairo City , find the project number, the controlling department name ,
-- the department manager last name ,address and birthdate.
SELECT p.Pnumber, d.Dname, e.Lname, e.Address, e.Bdate
FROM Departments d
INNER JOIN Project p ON d.Dnum = p.Dnum
INNER JOIN Employee e ON e.SSN = d.MGRSSN
WHERE p.City = 'Cairo';

-- 11. Display All Data of the managers
SELECT DISTINCT m.*
FROM Employee e INNER JOIN Employee m 
ON e.Superssn = m.SSN

-- 12. Display All Employees data and the data of their dependents even if they have no dependents
SELECT e.*, d.*
FROM Employee e LEFT OUTER JOIN Dependent d
ON e.SSN = d.ESSN;

-- 13. Insert your personal data to the employee table as a new employee in department number 30, SSN = 102672, Superssn = 112233, salary=3000.
INSERT INTO Employee 
VALUES ('Mohamed', 'Atef', 102672, 6/4/2002, '2st alayaed alex', 'M', 3000, 112233, 30);

-- 14. Insert another employee with personal data your friend as new employee in department number 30, SSN = 102660, but don’t enter any value for salary or supervisor number to him.
INSERT INTO Employee (Fname, Lname, SSN, Sex, Dno)
VALUES ('Mohamed', 'Muslim', 102660, 'M', 30);

-- 15. Upgrade your salary by 20 % of its last value.
UPDATE Employee
SET Salary += (Salary * 20 / 100)
WHERE SSN = 102672;
