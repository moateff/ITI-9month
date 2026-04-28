using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Customers")]
public class Customer
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 2)]
    [NameValidation]
    public string Name { get; set; }

    [Required]
    [EnumDataType(typeof(GenderType))]
    public GenderType Gender { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [Phone]
    [Display(Name = "Phone Number")]
    [EgyptianPhone]
    public string PhoneNum { get; set; }

    public virtual IEnumerable<Order>? Orders { get; set; }
}