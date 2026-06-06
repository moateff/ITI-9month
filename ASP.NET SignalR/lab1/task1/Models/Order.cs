using System.ComponentModel.DataAnnotations;

namespace task1.Models;

public class Order
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Customer name is required")]
    [MinLength(3, ErrorMessage = "Customer name must be at least 3 characters long")]
    [MaxLength(50, ErrorMessage = "Customer name must be at most 50 characters long")]
    [Display(Name = "Customer Name")]
    public string CustomerName { get; set; } = null!;

    [Required(ErrorMessage = "Product name is required")]
    [MinLength(3, ErrorMessage = "Product name must be at least 3 characters long")]
    [MaxLength(50, ErrorMessage = "Product name must be at most 50 characters long")]
    [Display(Name = "Product Name")]
    public string ProductName { get; set; } = null!;

    [Required(ErrorMessage = "Quantity is required")]
    [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
    public int Quantity { get; set; }
}
