USE ITI;

-- 1. Create a scalar function that takes date and returns Month name of that date.
CREATE FUNCTION GetMonthName (@InputDate DATE)
RETURNS NVARCHAR(20)
AS
BEGIN
    RETURN DATENAME(MONTH, @InputDate);
END;

SELECT dbo.GetMonthName('2025-03-15') AS MonthName;


-- 2. Create a multi-statements table-valued function that takes 2 integers and 
--    returns the values between them.
CREATE FUNCTION GetNumbersBetween
(
    @Start INT,
    @End   INT
)
RETURNS @Result TABLE
(
    Number INT
)
AS
BEGIN
    DECLARE @Current INT = @Start;
    
    IF (@Start <= @End)
        SET @Current = @Start;
    ELSE
        SET @Current = @End;

    WHILE @Current <= CASE WHEN @Start <= @End THEN @End ELSE @Start END
    BEGIN
        INSERT INTO @Result (Number)
        VALUES (@Current);

        SET @Current = @Current + 1;
    END

    RETURN;
END;

SELECT *
FROM GetNumbersBetween(8, 3);


-- 3. Create inline function that takes Student No and returns Department Name with Student full name.
CREATE FUNCTION GetStudentDepartment
(
    @StudentNo INT
)
RETURNS TABLE
AS
RETURN
(
    SELECT
        CONCAT(S.St_Fname, ' ', S.St_Lname) AS 'Student Full Name',
        D.Dept_Name AS 'Department Name'
    FROM Student S
    INNER JOIN Department D
        ON S.Dept_ID = D.Dept_ID
    WHERE S.St_Id = @StudentNo
);

SELECT *
FROM GetStudentDepartment(1);

-- 4. Create a scalar function that takes Student ID and returns a message to user 
--		a. If first name and Last name are null then display 'First name & last name are null'
--		b. If First name is null then display 'first name is null'
--		c. If Last name is null then display 'last name is null'
--		d. Else display 'First name & last name are not null'

CREATE FUNCTION CheckStudentNameStatus
(
    @StudentID INT
)
RETURNS VARCHAR(100)
AS
BEGIN
    DECLARE @FirstName VARCHAR(50);
    DECLARE @LastName VARCHAR(50);
    DECLARE @Message VARCHAR(100);

    SELECT
        @FirstName = St_Fname,
        @LastName  = St_Lname
    FROM Student
    WHERE St_Id = @StudentID;

    IF (@FirstName IS NULL AND @LastName IS NULL)
        SET @Message = 'First name & last name are null';
    ELSE IF (@FirstName IS NULL)
        SET @Message = 'first name is null';
    ELSE IF (@LastName IS NULL)
        SET @Message = 'last name is null';
    ELSE
        SET @Message = 'First name & last name are not null';

    RETURN @Message;
END;

SELECT dbo.CheckStudentNameStatus(14) AS NameStatus;

-- 5. Create inline function that takes integer which represents manager ID and 
--	  displays department name, Manager Name and hiring date 

CREATE FUNCTION GetManagerDepartmentInfo
(
    @ManagerID INT
)
RETURNS TABLE
AS
RETURN
(
    SELECT
        D.Dept_Name AS 'Department Name',
        I.Ins_Name AS 'Manager Name',
        D.Manager_hiredate AS 'Hiring Date'
    FROM Department D
    INNER JOIN Instructor I
        ON D.Dept_Manager = I.Ins_Id
    WHERE I.Ins_Id = @ManagerID
);

SELECT *
FROM GetManagerDepartmentInfo(10102);

-- 6. Create multi-statements table-valued function that takes a string
--		If string='first name' returns student first name
--		If string='last name' returns student last name 
--		If string='full name' returns Full Name from student table 
-- Note: Use “ISNULL” function

CREATE FUNCTION GetStudentNamesByType
(
    @NameType VARCHAR(50)
)
RETURNS @Result TABLE
(
    StudentName VARCHAR(200)
)
AS
BEGIN
    IF (@NameType = 'first name')
    BEGIN
        INSERT INTO @Result
        SELECT ISNULL(s.St_Fname, 'UNKNOWN')
        FROM Student s;
    END

    ELSE IF (@NameType = 'last name')
    BEGIN
        INSERT INTO @Result
        SELECT ISNULL(s.St_Lname, 'UNKNOWN')
        FROM Student s;
    END

    ELSE IF (@NameType = 'full name')
    BEGIN
        INSERT INTO @Result
        SELECT 
            ISNULL(s.St_Fname, 'UNKNOWN') + ' ' +
            ISNULL(s.St_Lname, 'UNKNOWN')
        FROM Student s;
    END

    RETURN;
END;

SELECT * 
FROM GetStudentNamesByType('first name');

-- 7. Write a query that returns the Student No and Student first name without the last char
SELECT 
    s.St_Id,
    SUBSTRING(s.St_Fname, 1, LEN(s.St_Fname) - 1) AS FirstName_WithoutLastChar
FROM Student s;

-- 8. Wirte query to delete all grades for the students Located in SD Department 
UPDATE sc
SET sc.Grade = NULL
FROM Stud_Course sc
INNER JOIN Student s
    ON sc.St_Id = s.St_Id
INNER JOIN Department d
    ON s.Dept_Id = d.Dept_Id
WHERE d.Dept_Name = 'SD';

-- Bonus:
-- 1. Give an example for hierarchyid Data type
CREATE TABLE Organization
(
    EmpID INT PRIMARY KEY,
    EmpName VARCHAR(50),
    JobTitle VARCHAR(50),
    OrgNode hierarchyid
);

INSERT INTO Organization VALUES
(1, 'Ahmed', 'CEO', hierarchyid::GetRoot()),
(2, 'Sara', 'HR Manager', hierarchyid::GetRoot().GetDescendant(NULL, NULL)),
(3, 'Omar', 'IT Manager', hierarchyid::GetRoot().GetDescendant(hierarchyid::GetRoot().GetDescendant(NULL, NULL), NULL)),
(4, 'Mona', 'HR Specialist', hierarchyid::GetRoot().GetDescendant(NULL, NULL).GetDescendant(NULL, NULL)),
(5, 'Yousef', 'Software Eng.', hierarchyid::GetRoot().GetDescendant(hierarchyid::GetRoot().GetDescendant(NULL, NULL), NULL).GetDescendant(NULL, NULL));

SELECT
    EmpID,
    EmpName,
    JobTitle,
    OrgNode.ToString() AS HierarchyPath
FROM Organization
ORDER BY OrgNode;

-- 2. Create a batch that inserts 3000 rows in the student table(ITI database). 
--	  The values of the st_id column should be unique and between 3000 and 6000. All values of the columns st_fname, st_lname, should be set to 'Jane', ' Smith' respectively.

DECLARE @Counter INT = 3000;

WHILE @Counter < 6000
BEGIN
    INSERT INTO Student (St_Id, St_Fname, St_Lname)
    VALUES (@Counter, 'Jane', 'Smith');

    SET @Counter = @Counter + 1;
END;

SELECT *
FROM Student;