using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace task2.Models;

[Table("Products")]
public class Product
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 3)]
    public string? Name { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string? Image { get; set; }

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }

    [Required]
    [StringLength(500, MinimumLength = 3)]
    public string? Description { get; set; }

    [Required]
    [ForeignKey("Customer")]
    [Display(Name = "Customer")]
    public int CustomerId { get; set; }

    public virtual Customer? Customer { get; set; }
}
