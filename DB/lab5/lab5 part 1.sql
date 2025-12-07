USE ITI;

-- 1. Retrieve number of students who have a value in their age. 
SELECT COUNT(s.St_Id)
FROM Student s
WHERE s.St_Age IS NOT NULL;

-- 2. Get all instructors Names without repetition
SELECT DISTINCT i.Ins_name
FROM Instructor i;

-- 3. Display student with the following Format (use isNull function)
--    Student ID	Student Full Name	Department name
SELECT ISNULL(s.St_Id, 'unknown') AS 'Student ID', 
	   ISNULL(s.St_Fname + ' ' + s.St_Lname,'unknown') AS 'Student Full Name',
	   ISNULL(d.Dept_Name, 'unknown') AS 'Department Name'
FROM Student s INNER JOIN Department d ON s.Dept_Id = d.Dept_Id;	

-- 4. Display instructor Name and Department Name 
--    Note: display all the instructors if they are attached to a department or not
SELECT ISNULL(i.Ins_Name, 'unknown') AS 'Instructor Name', 
	   ISNULL(d.Dept_Name, 'unknown') AS 'Department Name'
FROM Instructor i LEFT OUTER JOIN Department d ON i.Dept_Id = d.Dept_Id;

-- 5. Display student full name and the name of the course he is taking
--    For only courses which have a grade  
SELECT ISNULL(s.St_Fname + ' ' + s.St_Lname, 'unknown') AS 'Student Name',
	   c.Crs_Name AS 'Course Name'
FROM Course c 
INNER JOIN Stud_Course sc ON c.Crs_Id = sc.Crs_Id 
INNER JOIN Student s ON sc.St_Id = s.St_Id 
WHERE sc.Grade IS NOT NULL;

-- 6. Display number of courses for each topic name
SELECT t.Top_Name AS 'Topic Name', count(c.Crs_Id) AS 'Courses Count'
FROM Course c INNER JOIN Topic t ON c.Top_Id = t.Top_Id
GROUP BY c.Top_Id, t.Top_Name;

-- 7. Display max and min salary for instructors
SELECT MAX(i.Salary) AS 'Max Salary', MIN(i.Salary) AS 'Min Salary'
FROM Instructor i
WHERE i.Salary IS NOT NULL;

-- 8. Display instructors who have salaries less than the average salary of all instructors.
SELECT i.*
FROM Instructor i
WHERE i.Salary < (SELECT AVG(i.Salary) FROM Instructor i);

-- 9. Display the Department name that contains the instructor who receives the minimum salary.
SELECT d.Dept_Name
FROM Department d INNER JOIN Instructor i ON d.Dept_Id = i.Dept_Id
WHERE i.Salary = (SELECT MIN(i.Salary) FROM Instructor i);

-- 10. Select max two salaries in instructor table. 
SELECT DISTINCT TOP 2 i.Salary
FROM Instructor i
ORDER BY i.Salary DESC;

-- 11. Select instructor name and his salary but if there is no salary display instructor bonus keyword. �use coalesce Function�
SELECT i.Ins_Name, COALESCE(CONVERT(varchar(20), i.Salary), 'instructor bonus') AS Salary
FROM Instructor i;

-- 12. Select Average Salary for instructors 
SELECT AVG(i.Salary) AS 'Average Salary'
FROM Instructor i;

-- 13. Select Student first name and the data of his supervisor 
SELECT s.St_Fname + ' ' + s.St_Lname AS 'Student Name', sv.*
FROM Student s INNER JOIN Student sv ON s.St_super = sv.St_Id;

-- 14. Write a query to select the highest two salaries in Each Department for instructors who have salaries. �using one of Ranking Functions�
SELECT Dept_Id, Salary
FROM (
	SELECT *, ROW_NUMBER() OVER (PARTITION BY i.Dept_Id ORDER BY i.Salary DESC) AS SalaryRank
	FROM Instructor i
) AS RankedSalaries
WHERE SalaryRank <= 2;

-- 15. Write a query to select a random  student from each department.  �using one of Ranking Functions�
SELECT TOP 1 *
FROM (
	SELECT *, ROW_NUMBER() OVER (ORDER BY NEWID()) AS StudentRank
	FROM Student
) AS RankedStudents;