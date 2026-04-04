using System;

namespace Task
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeSearch emps = new EmployeeSearch(3);

            for (int i = 0; i < emps.Size; i++)
            {
                Console.WriteLine($"\nEnter data for employee #{i + 1}");

                Console.Write("ID: ");
                int id = int.Parse(Console.ReadLine()!);

                Console.Write("Name: ");
                string name = Console.ReadLine()!;

                Console.Write("Salary: ");
                double salary = double.Parse(Console.ReadLine()!);

                Console.Write("Gender (M or F): ");
                Gender gender = (Gender)Enum.Parse(typeof(Gender), Console.ReadLine()!, true);

                Console.Write("Hire Date (dd/mm/yyyy): ");
                Date hireDate = new Date(Console.ReadLine()!);

                SecurityLevel securityLevel;

                if (i == 0)
                    securityLevel = SecurityLevel.DBA;
                else if (i == 1)
                    securityLevel = SecurityLevel.Guest;
                else
                    securityLevel = SecurityLevel.Guest |
                          SecurityLevel.Developer |
                          SecurityLevel.Secretary |
                          SecurityLevel.DBA;

                Employee emp = new Employee(id, name, securityLevel, salary, hireDate, gender);
                
                emps.Add(i, emp);
            }

            Console.WriteLine("\n================= Search Employees =================\n");

            Console.WriteLine(emps[1]);
            Console.WriteLine(emps["Mohamed"]);
            Console.WriteLine(emps[new Date("2/2/2002")]);

            Console.WriteLine("");
        }
    }
}
