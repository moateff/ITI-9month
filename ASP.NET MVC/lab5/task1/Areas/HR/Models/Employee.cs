using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Employee
{
    [Key]
    public int EmpID { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Password { get; set; }

    public decimal Salary { get; set; }

    public DateTime joinDate { get; set; }

    [EmailAddress]
    public string Email { get; set; }

    public string PhoneNum { get; set; }

    [ForeignKey("Dept")]
    public int DeptID { get; set; } 

    public virtual Department? Dept { get; set; }
}