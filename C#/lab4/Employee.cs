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
    }
}