-- 1. Create a stored procedure without parameters to show the number of students per department name.[USE ITI DB] 
USE ITI;
GO

CREATE PROCEDURE Students_Per_Department
AS
BEGIN
	SELECT 
		d.Dept_Name AS Department, 
		COUNT(s.St_Id) AS 'Number of students'
	FROM Student s 
	JOIN Department d ON s.Dept_Id = d.Dept_Id
	GROUP BY d.Dept_Name
END

GO
Students_Per_Department

-- 2. Create a stored procedure that will check for the # of employees in the project p1 IF they are more than 3 
--    print message to the user 'The number of employees in the project p1 is 3 or more' IF they are less 
--    display a message to the user 'The following employees work for the project p1' in addition to the first name 
--    and last name of each one. [Company DB] 
USE SD;
GO

CREATE PROCEDURE Check_P1_Employees
AS
BEGIN
	DECLARE @count INT

	SELECT @count = COUNT(w.EmpNo)
	FROM Works_on w
	WHERE w.ProjectNo = 'p1'

	IF @count >= 3 
	BEGIN 
		SELECT 'The number of employees in the project p1 is 3 or more'  
	END 
	ELSE 
	BEGIN 
		SELECT 'The following employees work for the project p1'
				
		SELECT 
			e.EmpFname, 
			e.EmpLname
		FROM Works_on w 
		JOIN [Human Resource].Employee e ON w.EmpNo = e.EmpNo
		WHERE w.ProjectNo = 'p1'
	END
END

GO
Check_P1_Employees

-- 3. Create a stored procedure that will be used in case there is an old employee has left the project 
--    and a new one become instead of him. The procedure should take 3 parameters (old Emp. number, new Emp. 
--    number and the project number) and it will be used to UPDATE works_on table. [Company DB]

GO
CREATE PROCEDURE Switch_Employees
(
	@old_emp_number INT, 
	@new_emp_number INT , 
	@project_number INT
)
AS
BEGIN
	UPDATE Works_on
	SET EmpNo = @new_emp_number
	WHERE EmpNo = @old_emp_number AND ProjectNo = @project_number
END

-- 4. add column budget in project table and INSERT any draft VALUES in it then 
--	  then Create an Audit table with the following structure 
--    ProjectNo 	UserName 	ModifiedDate 	Budget_Old 	Budget_New 
--    p2 			Dbo 		2008-01-31		95000 		200000 

-- This table will be used to audit the UPDATE trials ON the Budget column (Project table, Company DB)
-- Example:
-- If a user updated the budget column then the project number, user name that made that UPDATE, 
-- the date of the modification and the value of the old and the new budget will be inserted INTO the Audit table
-- Note: This process will take place only IF the user updated the budget column

CREATE TABLE audit
(
	ProjectNo NCHAR(10), 
	UserName VARCHAR(30), 
	ModifiedDate DATE, 
	Budget_Old INT, 
	Budget_New INT 
)
GO

CREATE TRIGGER On_Budget_Update
ON Project
FOR UPDATE
AS
BEGIN
	IF UPDATE(Budget)
	BEGIN
		DECLARE @project_number NCHAR(10), @old_budget INT, @new_budget INT

		SELECT @project_number = ProjectNo, @old_budget = Budget  FROM deleted
		SELECT @new_budget = Budget FROM inserted
		
		INSERT INTO audit
		VALUES
		(
			@project_number, 
			SUSER_NAME(), 
			GETDATE(), 
			@old_budget, 
			@new_budget
		)
	END
END

GO

UPDATE Project 
SET Budget = 100000 
WHERE ProjectNo = 'p1' 

SELECT * FROM audit
SELECT * FROM Project
GO

-- 5. Create a trigger to prevent anyone FROM inserting a new record in the Department table [ITI DB]
--    "Print a message for user to tell him that he can�t INSERT a new record in that table"
USE ITI;

CREATE TRIGGER Prevent_New_Record
ON Department
INSTEAD OF INSERT
AS
BEGIN
	SELECT 'Invalid Operation, cant INSERT a new record in Department'
END

INSERT INTO Department 
VALUES (80, 'EB', 'E-Business', 'Alex',	NULL, NULL)

-- 6. Create a trigger that prevents the insertion Process for Employee table in March [Company DB].

USE SD;

CREATE TRIGGER PreventNewEmpMarch
ON [HR].Employee
AFTER INSERT
AS
BEGIN
	IF (FORMAT(GETDATE(),'MMMM') = 'March')
	BEGIN
		DELETE FROM [HR].Employee 
		WHERE EmpNo = (SELECT EmpNo FROM inserted)
		SELECT 'No insertion allowed in March'
	END
END

-- 7. Create a trigger ON student table AFTER INSERT to add Row in Student Audit table (Server User Name , Date, Note) 
--    WHERE note will be �[username] Insert New Row with Key=[Key Value] in table [table name]�
--    Server User Name		Date       Note 

USE ITI;

CREATE TABLE Student_Audit
(
	ServerUserName VARCHAR(100), 
	InsertionDate DATE, 
	Note VARCHAR(200)
)

CREATE TRIGGER Archive_Student
ON Student
AFTER INSERT
AS
BEGIN
	DECLARE @student_id INT
	SELECT @student_id = St_Id FROM inserted
				
	INSERT INTO Student_Audit
	VALUES
	(
		SUSER_NAME(), 
		GETDATE(),
		CONCAT(SUSER_NAME(), ' ', 'Insert New Row with Key=', @student_id, ' ', 'in table student')
	)
END


INSERT INTO Student VALUES (15, 'Mohamed', 'Atef', 'Alex', 23, 30, 9)
SELECT * FROM Student_Audit
		
-- 8. Create a trigger ON student table instead of DELETE to add Row in Student Audit table (Server User Name, Date, Note) 
--    WHERE note will be� try to DELETE Row with Key=[Key Value]�

CREATE TRIGGER Prevent_Student_Delete
ON Student
INSTEAD OF DELETE
AS
BEGIN
	DECLARE @student_id INT
	SELECT @student_id = St_Id FROM deleted
				
	INSERT INTO Student_Audit
	VALUES
	(
		SUSER_NAME(), 
		GETDATE(),
		CONCAT(SUSER_NAME(), ' ', 'tried to DELETE Row with Key=', @student_id, ' ', 'in table student')
	)
END


DELETE FROM Student WHERE St_Id = 15
SELECT * FROM Student_Audit 
