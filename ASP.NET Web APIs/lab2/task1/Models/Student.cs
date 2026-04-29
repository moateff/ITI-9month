using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using task1.Validations;

namespace task1.Models;

[Table("Students")]
public class Student
{
    [Key]
    public int SSN { get; set; }

    [Required]
    [StringLength(12, MinimumLength = 5, ErrorMessage = "Name must be between 5 and 12 characters long")]
    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name must contain only letters and spaces")]
    public string? Name { get; set; }

    [Required]
    [Range(18, 20, ErrorMessage = "Age must be between 18 and 20")]
    public int Age { get; set; }

    [Required]
    [EmailAddress]
    [UniqueEmailAddress]
    [StringLength(50, ErrorMessage = "Email must be at most 50 characters long")]
    public string? Email { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "Image URL must be at most 100 characters long")]
    public string? Image { get; set; }

    [Required]
    [Range(1, 5, ErrorMessage = "Level must be between 1 and 5")]
    public int Level { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [DateInPast]
    [DateOfBirthAgeMatch]
    public DateOnly DateOfBirth { get; set; }
}
