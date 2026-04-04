using System;

namespace Task
{
    public struct Employee
    {
        public int id;
        public SecurityLevel securityLevel;
        public double salary;
        public Date hireDate;
        public Gender gender;

        public Employee(int id, SecurityLevel securityLevel, double salary, Date hireDate, Gender gender)
        {
            this.id = id;
            this.securityLevel = securityLevel;
            this.salary = salary;
            this.hireDate = hireDate;
            this.gender = gender;
        }

        public int GetId() { return id; }
        public void SetId(int id) { this.id = id; }
        public SecurityLevel GetSecurityLevel() { return securityLevel; }
        public void SetSecurityLevel(SecurityLevel securityLevel) { this.securityLevel = securityLevel; }
        public double GetSalary() { return this.salary; }
        public void SetSalary(double salary) { this.salary = salary; }
        public Date GetHireDate() { return hireDate; }
        public void SetHireDate(Date hireDate) { this.hireDate = hireDate; }
        public Gender GetGender() { return gender; } 
        public void SetGender(Gender gender) { this.gender = gender; }

        public override string ToString()
        {
            return $"ID: {id}, Gender: {gender}, Hire Date: {hireDate}, Security Level: {securityLevel}, Salary: {String.Format("{0:C}", salary)}";
        }
    }
}