using System;

namespace Task
{
    public struct Employee
    {
        public int Id { set; get; }
        public string Name {set; get; }
        public SecurityLevel SecurityLevel { set; get; }
        public double Salary { set; get; }
        public Date HireDate { set; get; }
        public Gender Gender { set; get; }

        public Employee(int id, string name, SecurityLevel securityLevel, double salary, Date hireDate, Gender gender)
        {
            this.Id = id;
            this.Name = name;
            this.SecurityLevel = securityLevel;
            this.Salary = salary;
            this.HireDate = hireDate;
            this.Gender = gender;
        }

        public override string ToString()
        {
            return $"{Id}, {Name}, {Gender}, {HireDate}, {SecurityLevel}, {String.Format("{0:C}", Salary)}";
        }

        public static Employee ReadData()
        {
            int id;
            string? name;
            double salary;
            Date hireDate;
            Gender gender;
            SecurityLevel securityLevel;

            while (true)
            {
                Console.Write("ID: ");
                string? input = Console.ReadLine();

                if (int.TryParse(input, out id))
                    break;

                Console.WriteLine("Invalid input. Please try again.");
            }

            while (true)
            {
                Console.Write("Name: ");
                name = Console.ReadLine();

                if (name?.Length > 0)
                    break;

                Console.WriteLine("Invalid input. Please try again.");
            }

            while (true)
            {
                Console.Write("Salary: ");
                string? input = Console.ReadLine();

                if (double.TryParse(input, out salary))
                    break;

                Console.WriteLine("Invalid input. Please try again.");
            }

            while (true)
            {
                Console.Write("Gender (M or F): ");
                string? input = Console.ReadLine();

                if (Enum.TryParse<Gender>(input, true, out gender))
                    break;

                Console.WriteLine("Invalid input. Please try again.");
            }
            
            while (true)
            {
                Console.Write("Hire Date (dd/mm/yyyy): ");
                string? input = Console.ReadLine();

                if (Date.TryParse(input, out hireDate))
                    break;

                Console.WriteLine("Invalid input. Please try again.");
            }
            
            while (true)
            {
                Console.Write("Security Level (DBA, Guest, Developer, Secretary, SecurityOfficer): ");
                string? input = Console.ReadLine();

                if (Enum.TryParse<SecurityLevel>(input, true, out securityLevel))
                    break;

                Console.WriteLine("Invalid input. Please try again.");
            }
            
            return new Employee(id, name, securityLevel, salary, hireDate, gender);
        }
    }
}