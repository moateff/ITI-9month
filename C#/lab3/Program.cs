using System;

namespace Task
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee[] arr = new Employee[3];

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"\nEnter data for employee #{i + 1}");

                Console.Write("ID: ");
                int id = int.Parse(Console.ReadLine()!);

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

                arr[i] = new Employee(id, securityLevel, salary, hireDate, gender);
            }

            Console.WriteLine("\n================ Employees Data ================\n");

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"Employee #{i + 1}");
                Console.WriteLine(arr[i] + "\n");
            }
        }
    }
}
