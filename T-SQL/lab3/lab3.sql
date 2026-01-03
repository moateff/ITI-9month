Use ITI;

-- 1. Create a view that displays student full name, course name if the student has a grade more than 50. 

CREATE VIEW Student_Course_Data 
AS
    SELECT 
        CONCAT(s.St_Fname, ' ', s.St_Lname) AS FullName,
        c.Crs_Name AS CourseName
    FROM Student s
    JOIN Stud_Course sc ON s.St_Id = sc.St_Id
    JOIN Course c ON sc.Crs_Id = c.Crs_Id
    WHERE sc.Grade > 50;

SELECT * FROM Student_Course_Data;

-- 2. Create an Encrypted view that displays manager names and the topics they teach. 

CREATE VIEW Manager_Taught_Topics
WITH ENCRYPTION
AS
    SELECT
        i.Ins_Name AS ManagerName,
        t.Top_Name AS TopicName
    FROM Department d
    JOIN Instructor i ON d.Dept_Manager = i.Ins_Id
    JOIN Ins_Course ic ON i.Ins_Id = ic.Ins_Id
    JOIN Course c ON ic.Crs_Id = c.Crs_Id
    JOIN Topic t ON c.Top_Id = t.Top_Id;

SELECT * FROM Manager_Taught_Topics;

-- 3. Create a view that will display Instructor Name, Department Name for the ‘SD’ or ‘Java’ Department 

CREATE VIEW Dept_SD_Java_Instructors
AS
    SELECT
        i.Ins_Name  AS InstructorName,
        d.Dept_Name AS DepartmentName
    FROM Instructor i
    JOIN Department d
        ON i.Dept_Id = d.Dept_Id
    WHERE d.Dept_Name IN ('SD', 'Java');

SELECT * FROM Dept_SD_Java_Instructors;

-- 4. Create a view “V1” that displays student data for student who lives in Alex or Cairo. 
--	  Note: Prevent the users to run the following query 
--    Update V1 set st_address=’tanta’
--    Where st_address=’alex’;

CREATE VIEW V1
AS
    SELECT *
    FROM Student
    WHERE St_Address IN ('Alex', 'Cairo')
    WITH CHECK OPTION;

SELECT * FROM V1;

UPDATE V1
SET St_Address = 'Tanta'
WHERE St_Address = 'Alex';

-- 5. Create a view that will display the project name and the number of employees work on it. “Use SD database”

USE SD;

CREATE VIEW Project_Employee_Count
AS
    SELECT
        p.ProjectName,
        COUNT(w.EmpNo) AS EmployeeCount
    FROM Company.Project p
    JOIN Works_on w
        ON p.ProjectNo = w.ProjectNo
    GROUP BY
        p.ProjectName;

SELECT * FROM Project_Employee_Count;

-- 6. Create index on column (Hiredate) that allow u to cluster the data in table Department. What will happen?

CREATE CLUSTERED INDEX IX_Department_ManagerHireDate
ON Department(Manager_hiredate);

-- Cannot create more than one clustered index on table 'Department'. 
-- Drop the existing clustered index 'PK_Department' before creating another.

CREATE NONCLUSTERED  INDEX IX_Department_ManagerHireDate
ON Department(Manager_hiredate);
-- Commands completed successfully.

-- 7. Create index that allow u to enter unique ages in student table. What will happen? 

CREATE UNIQUE INDEX i_Age
ON Student (St_Age);

-- The CREATE UNIQUE INDEX statement terminated because a duplicate key was found for the object name 'dbo.Student'
-- and the index name 'i_Age'. The duplicate key value is (<NULL>).

-- 8. Using Merge statement between the following two tables [User ID, Transaction Amount]

-- Create tables
CREATE TABLE #daily (id INT, val INT);
CREATE TABLE #last  (id INT, val INT);

-- Insert data
INSERT INTO #daily VALUES (1,1000),(2,2000),(3,1000);
INSERT INTO #last  VALUES (1,4000),(4,2000),(2,10000);

MERGE INTO #last AS t
USING #daily AS d
ON t.id = d.id
WHEN MATCHED THEN 
    UPDATE SET t.val = d.val
WHEN NOT MATCHED BY TARGET THEN 
    INSERT (id, val) VALUES (d.id, d.val);

SELECT * FROM #last;

USE SD;
-- 1) Create view named “v_clerk” that will display employee#,project#, 
--     the date of hiring of all the jobs of the type 'Clerk'.

CREATE VIEW v_clerk
AS
    SELECT
        EmpNo,
        ProjectNo,
        Enter_Date
    FROM Works_on
    WHERE Job = 'Clerk';

SELECT * FROM v_clerk;

-- 2) Create view named  “v_without_budget” that will display all the projects data without budget

CREATE VIEW v_without_budget
AS
    SELECT *
    FROM Company.Project p
    WHERE p.Budget IS NULL;

SELECT * FROM v_without_budget;

-- 3) Create view named  “v_count “ that will display the project name and the # of jobs in it

CREATE VIEW v_count
AS
    SELECT
        p.ProjectName,
        COUNT(w.Job) AS JobCount
    FROM Company.Project p
    JOIN Works_on w
        ON p.ProjectNo = w.ProjectNo
    GROUP BY p.ProjectName;

SELECT * FROM v_count;

-- 4) Create view named ” v_project_p2” that will display the emp#  for the project# ‘p2’
--	  use the previously created view  “v_clerk”

CREATE VIEW v_project_p2
AS
    SELECT
        COUNT(EmpNo) AS EmpCount
    FROM v_clerk
    WHERE ProjectNo = 'p2';

SELECT * FROM v_project_p2;

-- 5) modifey the view named  “v_without_budget”  to display all DATA in project p1 and p2 

ALTER VIEW v_without_budget
AS
    SELECT *
    FROM Company.Project p
    WHERE p.ProjectNo IN ('p1', 'p2');

SELECT * FROM v_without_budget;

-- 6) Delete the views  “v_ clerk” and “v_count”

DROP VIEW v_clerk;
DROP VIEW v_count;

-- 7) Create view that will display the emp# and emp lastname who works on dept# is ‘d2’

CREATE VIEW d2_emps
AS
    SELECT
        EmpNo,
        EmpLname
    FROM [Human Resource].Employee
    WHERE DeptNo = 'd2';

SELECT * FROM d2_emps;


-- 8) Display the employee  lastname that contains letter “J”
--    Use the previous view created in Q#7

SELECT EmpLname
FROM d2_emps
WHERE EmpLname LIKE '%J%';

-- 9) Create view named “v_dept” that will display the department# and department name.

CREATE VIEW v_dept
AS
    SELECT
        DeptNo,
        DeptName
    FROM Company.Department;

SELECT * FROM v_dept;

-- 10) using the previous view try enter new department data where dept# is ’d4’ and dept name is ‘Development’

INSERT INTO v_dept 
VALUES ('d4', 'Development');
-- (1 row affected)

-- 11) Create view name “v_2006_check” that will display employee#, the project #where he works and the date of 
--     joining the project which must be from the first of January and the last of December 2006

CREATE VIEW v_2006_check
AS
    SELECT
        EmpNo,
        ProjectNo,
        Enter_Date
    FROM Works_on
    WHERE Enter_Date BETWEEN '2006-01-01' AND '2006-12-31';

SELECT * FROM v_2006_check;
