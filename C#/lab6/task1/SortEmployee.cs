using System;

namespace Task
{
    public static class SortEmployee
    {
        private static void Swap(Employee[] employees, int i, int j)
        {
            Employee temp = employees[i];
            employees[i] = employees[j];
            employees[j] = temp;
        }
        public static void SortOnHireDate(Employee[] employees)
        {
            for (int i = 0; i < employees.Length - 1; i++)
            {
                bool swapped = false;

                for (int j = 0; j < employees.Length - i - 1; j++)
                {
                    if (employees[j].HireDate > employees[j + 1].HireDate)
                    {
                        Swap(employees, j, j + 1);
                        swapped = true;
                    }
                }

                if (!swapped)
                    break;
            }
        }
    }
}
