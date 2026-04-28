using System.ComponentModel.DataAnnotations;
using task2.Models;

namespace task2.ViewModels;

public class CustomerProductsViewModel
{
    public int CustomerId { get; set; }
    [Display(Name = "Customer")]
    public string? CustomerName { get; set; }
    public IEnumerable<Product>? Products { get; set; }
}