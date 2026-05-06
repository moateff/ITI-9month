using System.ComponentModel.DataAnnotations;

namespace task1.Data;

public class Track
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MinLength(3, ErrorMessage = "Name must be at least 3 characters long")]
    [MaxLength(50, ErrorMessage = "Name cannot be longer than 50 characters")]
    public string? Name { get; set; }

    [Required]
    [MinLength(3, ErrorMessage = "Description must be at least 3 characters long")]
    [MaxLength(500, ErrorMessage = "Description cannot be longer than 500 characters")]
    public string? Description { get; set; }
}