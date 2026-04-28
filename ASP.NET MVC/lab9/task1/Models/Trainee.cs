using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using task1.Enums;

namespace task1.Models;

[Table("Trainees")]
public class Trainee
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 2)]
    public string Name { get; set; }

    [Required]
    [EnumDataType(typeof(GenderType))]
    public GenderType Gender { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [Phone]
    [Display(Name = "Phone")]
    public string PhoneNumber { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime Birthdate { get; set; }

    [Required]
    [ForeignKey("Track")]
    [Display(Name = "Track")]
    public int TrackId { get; set; }
    
    public virtual Track? Track { get; set; }
}