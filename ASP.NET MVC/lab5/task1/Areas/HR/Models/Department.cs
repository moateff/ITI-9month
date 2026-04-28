using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Department
{
    [Key]
    public int DeptID { get; set; }

    [Required]
    public string Name { get; set; }

    public string Description { get; set; }

    public virtual List<Employee>? Employees { get; set; }
}