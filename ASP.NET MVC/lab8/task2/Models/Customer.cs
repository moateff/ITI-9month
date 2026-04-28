using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using task2.Enums;

namespace task2.Models;

[Table("Customers")]
public class Customer
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 2)]
    public string? Name { get; set; }

    [Required]
    [EnumDataType(typeof(GenderType))]
    public GenderType Gender { get; set; }

    [Required]
    [EmailAddress]
    [StringLength(50, MinimumLength = 2)]
    public string? Email { get; set; }

    [Required]
    [Phone]
    [StringLength(50, MinimumLength = 2)]
    [Display(Name = "Phone")]
    public string? PhoneNumber { get; set; }


    public IEnumerable<Product>? Products { get; set; }
}
