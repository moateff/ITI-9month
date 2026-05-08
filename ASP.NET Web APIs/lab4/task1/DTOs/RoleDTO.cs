using System.ComponentModel.DataAnnotations;

namespace task1.DTOs;

public class RoleDTO
{
    [Required]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Role name must be between 3 and 50 characters long")]
    [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Role name must contain only letters")]
    public string? Name { get; set; }
}