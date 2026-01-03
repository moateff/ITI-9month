-- 1. Create a cursor for Employee table that increases Employee salary by 10% 
--    if Salary <3000 and increases it by 20% if Salary >=3000. Use company DB
USE SD;
GO

SELECT EmpNo, Salary
FROM [Human Resource].Employee;
GO

DECLARE c_EmployeeSalary CURSOR
FOR
    SELECT EmpNo, Salary
    FROM [Human Resource].Employee
    FOR UPDATE OF Salary;

DECLARE 
    @EmpID INT,
    @Salary INT;

OPEN c_EmployeeSalary;

FETCH NEXT FROM c_EmployeeSalary INTO @EmpID, @Salary;

WHILE @@FETCH_STATUS = 0
BEGIN
    IF @Salary < 3000
        UPDATE [Human Resource].Employee
        SET Salary = @Salary * 1.10
        WHERE CURRENT OF c_EmployeeSalary;
    ELSE
        UPDATE [Human Resource].Employee
        SET Salary = @Salary * 1.20
        WHERE CURRENT OF c_EmployeeSalary;

    FETCH NEXT FROM c_EmployeeSalary INTO @EmpID, @Salary;
END

CLOSE c_EmployeeSalary;
DEALLOCATE c_EmployeeSalary;
GO

SELECT EmpNo, Salary
FROM [Human Resource].Employee;
GO

-- 2. Display Department name with its manager name using cursor. Use ITI DB

USE ITI;
GO

DECLARE c_DepartmentManagers CURSOR
FOR
    SELECT d.Dept_Name, i.Ins_Name
    FROM Department d
    JOIN Instructor i
        ON d.Dept_Manager = i.Ins_Id;

DECLARE 
    @DeptName NVARCHAR(50),
    @ManagerName NVARCHAR(50);

OPEN c_DepartmentManagers;

FETCH NEXT FROM c_DepartmentManagers 
INTO @DeptName, @ManagerName;

WHILE @@FETCH_STATUS = 0
BEGIN
    SELECT 
        @DeptName AS [Department Name],
        @ManagerName AS [Manager Name];

    FETCH NEXT FROM c_DepartmentManagers 
    INTO @DeptName, @ManagerName;
END

CLOSE c_DepartmentManagers;
DEALLOCATE c_DepartmentManagers;
GO

SELECT d.Dept_Name AS [Department Name],
       i.Ins_Name  AS [Manager Name]
FROM Department d
JOIN Instructor i
     ON d.Dept_Manager = i.Ins_Id;

-- 3. Try to display all students first name in one cell separated by comma. Using Cursor 

USE ITI;
GO

DECLARE c_StudentNames CURSOR
FOR
    SELECT St_Fname
    FROM Student
    WHERE St_Fname IS NOT NULL;

DECLARE 
    @Name  VARCHAR(50),
    @AllNames VARCHAR(1000) = '',
    @IsFirst BIT = 1;

OPEN c_StudentNames;

FETCH NEXT FROM c_StudentNames INTO @Name;

WHILE @@FETCH_STATUS = 0
BEGIN
    IF @IsFirst = 1
    BEGIN
        SET @AllNames = @Name;
        SET @IsFirst = 0;
    END
    ELSE
    BEGIN
        SET @AllNames = CONCAT(@AllNames, ', ', @Name);
    END

    FETCH NEXT FROM c_StudentNames INTO @Name;
END

CLOSE c_StudentNames;
DEALLOCATE c_StudentNames;

SELECT @AllNames AS [All Student First Names];
GO

-- 4. Create a sequence object that allow values from 1 to 10 without cycling in a specific column 
--    and test it.

USE ITI;
GO

CREATE SEQUENCE seq_TestID
    START WITH 1
    INCREMENT BY 1
    MINVALUE 1
    MAXVALUE 10
    NO CYCLE;
GO

CREATE TABLE #TestSeq
(
    ID INT
);
GO

-- Insert 10 values (valid range)
INSERT INTO #TestSeq (ID)
VALUES 
    (NEXT VALUE FOR seq_TestID),
    (NEXT VALUE FOR seq_TestID),
    (NEXT VALUE FOR seq_TestID),
    (NEXT VALUE FOR seq_TestID),
    (NEXT VALUE FOR seq_TestID),
    (NEXT VALUE FOR seq_TestID),
    (NEXT VALUE FOR seq_TestID),
    (NEXT VALUE FOR seq_TestID),
    (NEXT VALUE FOR seq_TestID),
    (NEXT VALUE FOR seq_TestID);

SELECT * FROM #TestSeq;
GO

INSERT INTO #TestSeq (ID)
VALUES (NEXT VALUE FOR seq_TestID);
-- The sequence object 'seq_TestID' has reached its minimum or maximum value. 
-- Restart the sequence object to allow new values to be generated.

GO

-- 5. Create snapshot of adventureworks_db and test it

-- Check logical file name
USE AdventureWorks2012;
GO
EXEC sp_helpfile;
GO

CREATE DATABASE AdventureWorks2012_Snap
ON
(
    NAME = AdventureWorks2012_Data,
    FILENAME = 'S:\ITI-9month\DB\lab10\AdventureWorks_Snap.ss'
)
AS SNAPSHOT OF AdventureWorks2012;
GO

SELECT COUNT(*) AS EmployeeCount
FROM AdventureWorks2012_Snap.HumanResources.Employee;

-- 6. Transform all functions in day2 to Stored Procedures

-- Create a scalar function that takes date and returns Month name of that date.
GO
CREATE PROCEDURE GetMonthName_SP(@InputDate DATE)
AS
BEGIN
    SELECT DATENAME(MONTH, @InputDate) AS MonthName;
END;

EXEC GetMonthName_SP '2025-03-15';

-- Create a multi-statements table-valued function that takes 2 integers and 
-- returns the values between them.
GO
CREATE PROCEDURE GetNumbersBetween_SP(@Start INT, @End INT)
AS
BEGIN
    DECLARE @Result TABLE (Number INT);
    DECLARE @Current INT;
    DECLARE @Limit   INT;

    IF (@Start < @End)
    BEGIN
        SET @Current = @Start;
        SET @Limit   = @End;
    END
    ELSE
    BEGIN
        SET @Current = @End;
        SET @Limit   = @Start;
    END

    WHILE (@Current <= @Limit)
    BEGIN
        INSERT INTO @Result (Number)
        VALUES (@Current);

        SET @Current = @Current + 1;
    END

    SELECT * FROM @Result;
END;

EXEC GetNumbersBetween_SP 8, 3;

-- Create inline function that takes Student No and returns Department Name with Student full name.
GO
CREATE PROCEDURE GetStudentDepartment_SP(@StudentNo INT)
AS
BEGIN
    SELECT
        CONCAT(S.St_Fname, ' ', S.St_Lname) AS [Student Full Name],
        D.Dept_Name AS [Department Name]
    FROM Student S
    INNER JOIN Department D
        ON S.Dept_ID = D.Dept_ID
    WHERE S.St_Id = @StudentNo;
END;

EXEC GetStudentDepartment_SP 1;

-- Create a scalar function that takes Student ID and returns a message to user 
--		a. If first name and Last name are null then display 'First name & last name are null'
--		b. If First name is null then display 'first name is null'
--		c. If Last name is null then display 'last name is null'
--		d. Else display 'First name & last name are not null'
GO
CREATE PROCEDURE CheckStudentNameStatus_SP(@StudentID INT)
AS
BEGIN
    DECLARE @FirstName VARCHAR(50);
    DECLARE @LastName  VARCHAR(50);
    DECLARE @Message   VARCHAR(100);

    SELECT
        @FirstName = St_Fname,
        @LastName = St_Lname
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

    SELECT @Message AS NameStatus;
END;

EXEC CheckStudentNameStatus_SP 14;


-- Create inline function that takes integer which represents manager ID and 
-- displays department name, Manager Name and hiring date 
GO
CREATE PROCEDURE GetManagerDepartmentInfo_SP(@ManagerID INT)
AS
BEGIN
    SELECT
        D.Dept_Name AS [Department Name],
        I.Ins_Name AS [Manager Name],
        D.Manager_hiredate AS [Hiring Date]
    FROM Department D
    INNER JOIN Instructor I
        ON D.Dept_Manager = I.Ins_Id
    WHERE I.Ins_Id = @ManagerID;
END;

EXEC GetManagerDepartmentInfo_SP 10102;

-- Create multi-statements table-valued function that takes a string
--		If string='first name' returns student first name
--		If string='last name' returns student last name 
--		If string='full name' returns Full Name from student table 
-- Note: Use “ISNULL” function
GO
CREATE PROCEDURE GetStudentNamesByType_SP(@NameType VARCHAR(50))
AS
BEGIN
    IF (@NameType = 'first name')
    BEGIN
        SELECT ISNULL(St_Fname, 'UNKNOWN') AS StudentName
        FROM Student;
    END
    ELSE IF (@NameType = 'last name')
    BEGIN
        SELECT ISNULL(St_Lname, 'UNKNOWN') AS StudentName
        FROM Student;
    END
    ELSE IF (@NameType = 'full name')
    BEGIN
        SELECT
            ISNULL(St_Fname, 'UNKNOWN') + ' ' +
            ISNULL(St_Lname, 'UNKNOWN') AS StudentName
        FROM Student;
    END
END;

EXEC GetStudentNamesByType_SP 'first name';


-- 7. Create full, differential Backup for SD DB.
BACKUP DATABASE SD
TO DISK = 'S:\ITI-9month\DB\lab10\SD_full.bak';

BACKUP DATABASE SD
TO DISK = 'S:\ITI-9month\DB\lab10\SD_diff.bak'
WITH DIFFERENTIAL;

-- 8. Use display student’s data (ITI DB) in excel sheet

USE ITI;
SELECT *
FROM Student;