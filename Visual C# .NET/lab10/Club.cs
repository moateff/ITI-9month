using System;

namespace Task
{
    class Club
    {
        public int ClubID { get; set; }
        public String ClubName { get; set; }
        List<Employee> Members = new();

        public void AddMember(Employee E)
        {
            if (E == null)
                return;

            // Check if already a member
            if (Members.Contains(E) == true)
            {
                Console.WriteLine($"Employee with ID: {E.EmployeeID} already exist at Club with ID: {ClubID}");
            }
            else
            {
                Console.WriteLine($"Adding Employee with ID: {E.EmployeeID} to Club with ID: {ClubID}");
                Members.Add(E);

                if (E is not BoardMember)
                {
                    // Register for the layoff event
                    E.EmployeeLayOff += RemoveMember;
                }
            }
        }

        public void RemoveMember(object sender, EmployeeLayOffEventArgs e)
        {
            if (sender is not Employee E)
                return;

            if (Members.Contains(E) == true)
            {
                if (e.Cause == LayOffCause.VacationStockNegative)
                {
                    Console.WriteLine($"Removing Employee with ID: {E.EmployeeID} to Club with ID: {ClubID} for {e.Cause}");
                    Members.Remove(E);

                    // Remove registeration for the layoff event
                    E.EmployeeLayOff -= RemoveMember;
                }
            } 
            else
            {
                Console.WriteLine($"Employee with ID: {E.EmployeeID} does not exist at Club with ID: {ClubID}");
            }
        }
    }
}