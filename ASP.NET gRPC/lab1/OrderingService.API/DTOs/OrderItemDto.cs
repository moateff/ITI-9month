using System.ComponentModel.DataAnnotations;

namespace OrderingService.API.DTOs;

public class OrderItemDto
{
    [Required]
    public int Id { get; set; }

    [Required]
    public int Price { get; set; }

    [Required]
    public int Quantity { get; set; }
}