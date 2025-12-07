USE Company_SD;

-- 1. Display (Using Union Function)
-- a. The name and the gender of the dependence that's gender is Female and depending on Female Employee.
-- b. And the male dependence that depends on Male Employee.
SELECT d.Dependent_name, d.Sex
FROM Dependent d INNER JOIN Employee e ON e.SSN = d.ESSN
WHERE d.Sex = 'F' AND e.Sex = 'F'
UNION
SELECT d.Dependent_name, d.Sex
FROM Dependent d INNER JOIN Employee e ON e.SSN = d.ESSN
WHERE d.Sex = 'M' AND e.Sex = 'M';

-- 2. For each project, list the project name and the total hours per week (for all employees) spent on that project.
SELECT p.Pname, SUM(w.Hours) AS 'Total Hours'
FROM Project p INNER JOIN Works_for w 
ON p.Pnumber = w.Pno
GROUP BY p.Pname;

-- 3. Display the data of the department which has the smallest employee ID over all employees' ID.
SELECT d.*
FROM Departments d
WHERE d.Dnum = (SELECT e.Dno FROM Employee e WHERE e.SSN = (SELECT MIN(SSN) FROM Employee));

-- 4. For each department, retrieve the department name and the maximum, minimum and average salary of its employees.
SELECT d.Dname, MAX(e.Salary) AS maxSalary, MIN(e.Salary) AS minSalary, AVG(e.Salary) AS avgSalary
FROM Employee e INNER JOIN Departments d ON e.Dno = d.Dnum
GROUP BY d.Dname;

-- 5. List the full name of all managers who have no dependents.
SELECT e.Fname + ' ' + e.Lname AS 'Full Name'
FROM Employee e INNER JOIN Departments d ON e.SSN = d.MGRSSN
WHERE e.SSN NOT IN (SELECT DISTINCT d.ESSN FROM Dependent d);

-- 6. For each department-- if its average salary is less than the average salary of all employees-- display its number, name and number of its employees.
SELECT d.Dnum, d.Dname, COUNT(e.SSN) AS employeeNum
FROM Departments d INNER JOIN Employee e ON d.Dnum = e.Dno
GROUP BY d.Dnum, d.Dname
HAVING AVG(e.Salary) < (SELECT AVG(e.Salary) FROM Employee e);

-- 7. Retrieve a list of employees names and the projects names they are working on ordered by department number and within each department, ordered alphabetically by last name, first name.
SELECT d.Dnum, e.Fname + ' ' + e.Lname AS 'Full Name', p.Pname
FROM Employee e 
INNER JOIN Departments d ON e.Dno = d.Dnum
INNER JOIN Works_for w ON e.SSN = w.ESSn
INNER JOIN Project p ON p.Pnumber = w.Pno
ORDER BY d.Dnum, e.Lname, e.Fname;

-- 8. Try to get the max 2 salaries using subquery
SELECT e.Salary
FROM Employee e
WHERE e.Salary IN (
    SELECT MAX(e.Salary) FROM Employee e
    UNION
    SELECT MAX(e.Salary) 
    FROM Employee e
    WHERE e.Salary < (SELECT MAX(e.Salary) FROM Employee e)
);

-- 9. Get the full name of employees that is similar to any dependent name
SELECT e.Fname + ' ' + e.Lname AS 'Full Name'
FROM Employee e
WHERE e.Fname + ' ' + e.Lname IN (SELECT d.Dependent_name FROM Dependent d);

-- 10. Display the employee number and name if at least one of them have dependents (use exists keyword) self-study.
SELECT e.SSN, e.Fname + ' ' + e.Lname AS 'Full Name'
FROM Employee e
WHERE EXISTS (SELECT ESSN FROM Dependent d);

-- 11. In the department table insert new department called "DEPT IT" , with id 100, employee with SSN = 112233 as a manager for this department. The start date for this manager is '1-11-2006'
INSERT INTO Departments 
VALUES ('DEPT IT', 100, 112233, '1-11-2006');

-- 12. Do what is required if you know that : Mrs.Noha Mohamed (SSN=968574)  moved to be the manager of the new department (id = 100), and they give you(your SSN =102672) her position (Dept. 20 manager) 
-- a. First try to update her record in the department table
UPDATE Departments 
SET MGRSSN = 968574, [MGRStart Date] = GETDATE()
WHERE Dnum = 100;

-- b. Update your record to be department 20 manager.
UPDATE Departments 
SET MGRSSN = 102672, [MGRStart Date] = GETDATE()
WHERE Dnum = 20;

-- c. Update the data of employee number=102660 to be in your teamwork (he will be supervised by you) (your SSN =102672)
UPDATE Employee 
SET Superssn = 102672
WHERE SSN = 102660;

-- 13. Unfortunately the company ended the contract with Mr. Kamel Mohamed (SSN=223344) so try to delete his data 
--     from your database in case you know that you will be temporarily in his position.
--     Hint: (Check if Mr. Kamel has dependents, works as a department manager, supervises any employees 
--     or works in any projects and handle these cases).

UPDATE Departments 
SET MGRSSN = 102672, [MGRStart Date] = GETDATE()
WHERE MGRSSN = 223344;

UPDATE Employee 
SET Superssn = 102672
WHERE Superssn = 223344;

UPDATE Works_for  
SET ESSn = 102672
WHERE ESSn = 223344;

DELETE FROM Dependent
WHERE ESSN = 223344;

DELETE FROM Employee
WHERE SSN = 223344;

-- 14. Try to update all salaries of employees who work in Project ‘Al Rabwah’ by 30%
UPDATE Employee
SET Salary = 1.3 * Salary
WHERE SSN IN (
	SELECT e.SSN 
	FROM Works_for w 
    INNER JOIN Employee e ON w.ESSn = e.SSN
    INNER JOIN Project p ON w.Pno = p.Pnumber
	WHERE p.Pname = 'Al Rabwah'
)
