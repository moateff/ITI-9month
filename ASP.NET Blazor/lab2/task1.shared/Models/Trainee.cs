using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using task1.shared.Enums;

namespace task1.shared.Models;

[Table("Trainees")]
public class Trainee
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MinLength(3, ErrorMessage = "Name must be at least 3 characters long")]
    [MaxLength(50, ErrorMessage = "Name cannot be longer than 50 characters")]
    public string? Name { get; set; }

    [Required]
    [EnumDataType(typeof(Gender))]
    public Gender Gender { get; set; }

    [Required]
    [MinLength(3, ErrorMessage = "Email Address must be at least 3 characters long")]
    [MaxLength(50, ErrorMessage = "Email Address cannot be longer than 50 characters")]
    [EmailAddress]
    public string? Email { get; set; }

    [Required]
    [MinLength(3, ErrorMessage = "Mobile Number must be at least 3 characters long")]
    [MaxLength(50, ErrorMessage = "Mobile Number cannot be longer than 50 characters")]
    [Phone]
    [Display(Name = "Mobile Number")]
    public string? MobileNumber { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [Display(Name = "Birth Date")]
    public DateOnly BirthDate { get; set; }

    [Required]
    [Display(Name = "Is Graduated?")]
    public bool IsGraduated { get; set; }

    [Required]
    [Display(Name = "Track")]
    public int TrackId { get; set; }

    public Track? Track { get; set; }
}
