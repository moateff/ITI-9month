using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using task1.Validations;

namespace task1.Models;

[Table("Departments")]
public class Department
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters")]
    [UniqueDepartmentName]
    public string? Name { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Location must be between 3 and 50 characters")]
    public string? Location { get; set; }

    [Required]
    [Phone]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Phone number must be between 3 and 50 characters")]
    public string? PhoneNumber { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Manager must be between 3 and 50 characters")]
    public string? Manger { get; set; }


    public virtual List<Student>? Students { get; set; }
}