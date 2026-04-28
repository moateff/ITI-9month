using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Orders")]
public class Order
{
    [Key]
    public int Id { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [Display(Name = "Order Date")]
    public DateTime Date { get; set; }

    [Required]
    [Display(Name = "Total Price")]
    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18, 2)")]
    [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
    [PositivePrice]
    public decimal TotalPrice { get; set; }

    [Required]
    [ForeignKey("Customer")]
    [Display(Name = "Customer")]
    public int CustomerId { get; set; }

    public virtual Customer? Customer { get; set; }
}