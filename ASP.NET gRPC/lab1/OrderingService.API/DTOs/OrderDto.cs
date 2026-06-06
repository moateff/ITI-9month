using System.ComponentModel.DataAnnotations;

namespace OrderingService.API.DTOs;

public class OrderDto
{
    [Required]
    public int Id { get; set; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public IEnumerable<OrderItemDto> Items { get; set; } = new List<OrderItemDto>();
}
