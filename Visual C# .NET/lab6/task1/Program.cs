using System;

namespace Task
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of employees: ");
            int n = int.Parse(Console.ReadLine()!);

            Employee[] emps = new Employee[n];

            for (int i = 0; i < emps.Length; i++)
            {
                Console.WriteLine($"\nEnter data for employee #{i + 1}");
                emps[i] = Employee.ReadData();
            }

            Console.WriteLine("\n================= Employees Data =================\n");

            for (int i = 0; i < emps.Length; i++)
            {
                Console.WriteLine(emps[i]);
            }

            SortEmployee.SortOnHireDate(emps);

            Console.WriteLine("\n================= Sorted Employees Data =================\n");

            for (int i = 0; i < emps.Length; i++)
            {
                Console.WriteLine(emps[i]);
            }
        }
    }
}
