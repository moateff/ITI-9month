using System;

namespace Task
{
    class Program
    {
        static void Main()
        {
            Department dept = new()
            {
                DeptID = 111,
                DeptName = "IT"
            };

            Club club = new()
            {
                ClubID = 222,
                ClubName = "Company Club"
            };

            // Normal employee 
            Employee emp1 = new()
            {
                EmployeeID = 1,
                BirthDate = new DateTime(1990, 1, 1),
                VacationStock = 5
            };

            Employee emp2 = new()
            {
                EmployeeID = 2,
                BirthDate = new DateTime(1960, 1, 1),
                VacationStock = 20
            };

            // Sales person
            SalesPerson sales = new()
            {
                EmployeeID = 3,
                BirthDate = new DateTime(1980, 1, 1),
                AchievedTarget = 40
            };

            // Board member
            BoardMember board = new()
            {
                EmployeeID = 4,
                BirthDate = new DateTime(1960, 1, 1),
            };

            // Add to department
            dept.AddStaff(emp1);
            dept.AddStaff(emp2);
            dept.AddStaff(sales);
            dept.AddStaff(board);

            // Add to club
            club.AddMember(emp1);
            club.AddMember(emp2);
            club.AddMember(sales);
            club.AddMember(board);

            Console.WriteLine("\n----- Normal employee1 -----");
            Console.WriteLine(emp1);

            Console.WriteLine("End of year (age < 60) will NOT be fired");
            emp1.EndOfYearOperation();

            Console.WriteLine($"Vacation request for 10 days (will be fired)");
            emp1.RequestVacation(DateTime.Today, DateTime.Today.AddDays(10));

            Console.WriteLine("\n----- Normal employee2 -----");
            Console.WriteLine(emp2);

            Console.WriteLine("Vacation request for 10 days (will NOT be fired)");
            emp2.RequestVacation(DateTime.Today, DateTime.Today.AddDays(10));
        
            Console.WriteLine("End of year (age > 60) will be fired");
            emp2.EndOfYearOperation();

            Console.WriteLine("\n----- Sales person -----");
            Console.WriteLine(sales);

            Console.WriteLine("Vacation request for 5 days (will NOT be fired)");
            sales.RequestVacation(DateTime.Today, DateTime.Today.AddDays(5));

            Console.WriteLine("End of year (age < 60) will be fired");
            sales.EndOfYearOperation();

            Console.WriteLine("Check target (not achieved) (will be fired)");
            sales.CheckTarget(100);

            Console.WriteLine("\n----- Board member -----");
            Console.WriteLine(board);

            Console.WriteLine("Vacation request for 5 days (will NOT be fired)");
            board.RequestVacation(DateTime.Today, DateTime.Today.AddDays(5));

            Console.WriteLine("End of year (age > 60) will be fired");
            board.EndOfYearOperation();

            Console.WriteLine("Resign (will be fired)");
            board.Resign();

            Console.WriteLine("\nFinished.");
        }
    }
}