using System;
using System.Data;
using System.Security.Principal;

namespace Task
{
    public struct EmployeeSearch
    {
        private int[] NationalIDs; 
        private Employee[] Employees;
        public int Size { get; }

        public EmployeeSearch(int size)
        {
            if (size > 0)
            {
                Size = size;
                NationalIDs = new int[size];
                Employees = new Employee[size];
            }
            else
            {
                throw new Exception("size should be greater than zero");
            }
        }

        public void Add(int index, Employee emp)
        {
            if ((index >= 0) && (index < Size))
            {
                NationalIDs[index] = emp.Id;
                Employees[index] = emp;
            }
        }

        public bool Search(int id, out Employee emp)
        {
            for (int i = 0; i < NationalIDs?.Length; i++)
            {
                if (NationalIDs[i] == id)
                {
                    emp = Employees[i];
                    return true;
                }
            }
            
            emp = default;
            return false;
        }

        
        public Employee this[int id]
        {
            get
            {
                for (int i = 0; i < NationalIDs?.Length; i++)
                {
                    if (NationalIDs[i] == id)
                    {
                        return Employees[i];
                    }
                }
            
                throw new Exception("Employee Id is not found");
            }
        }

        public bool Search(Date hireDate, out Employee emp)
        {
            for (int i = 0; i < Employees?.Length; i++)
            {
                if (Employees[i].HireDate.Equals(hireDate))
                {
                    emp = Employees[i];
                    return true;
                }
            }
            
            emp = default;
            return false;
        }

        public Employee this[Date hireDate]
        {
            get
            {
                for (int i = 0; i < NationalIDs?.Length; i++)
                {
                    if (Employees[i].HireDate.Equals(hireDate))
                    {
                        return Employees[i];
                    }
                }
            
                throw new Exception("Employee HireDate is not found");
            }
        }

        public bool Search(string name, out Employee emp)
        {
            for (int i = 0; i < Employees?.Length; i++)
            {
                if (Employees[i].Name == name)
                {
                    emp = Employees[i];
                    return true;
                }
            }
            
            emp = default;
            return false;
        }

        public Employee this[string name]
        {
            get
            {
                for (int i = 0; i < NationalIDs?.Length; i++)
                {
                    if (Employees[i].Name == name)
                    {
                        return Employees[i];
                    }
                }

                throw new Exception("Employee Name is not found");
            }
        }
    }
}
