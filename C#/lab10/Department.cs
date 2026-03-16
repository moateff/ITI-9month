using System;

namespace Task
{
    class Department
    {
        public int DeptID { get; set; }
        public string DeptName { get; set; }
        List<Employee> Staff = new();

        public void AddStaff (Employee E)
        {
            if (E == null)
                return;

            // Check if already at staff
            if (Staff.Contains(E) == true)
            {
                Console.WriteLine($"Employee with ID: {E.EmployeeID} already exist at Department with ID: {DeptID}");
            }
            else
            {
                Console.WriteLine($"Adding Employee with ID: {E.EmployeeID} to Department with ID: {DeptID}");
                Staff.Add(E);

                // Register for the layoff event
                E.EmployeeLayOff += RemoveStaff;
            }
        }

        public void RemoveStaff(object sender, EmployeeLayOffEventArgs e)
        {
            if (sender is not Employee E)
                return;

            if (Staff.Contains(E) == true)
            {
                Console.WriteLine($"Removing Employee with ID: {E.EmployeeID} from Department with ID: {DeptID} for {e.Cause}");
                Staff.Remove(E);

                // Remove registeration for the layoff event
                E.EmployeeLayOff -= RemoveStaff;
            }
            else
            {
                Console.WriteLine($"Employee with ID: {E.EmployeeID} does not exist at Department with ID: {DeptID}");
            } 
        }
    }
}