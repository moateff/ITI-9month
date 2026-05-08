using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using task1.Validations;

namespace task1.DTOs;

public class RegisterDTO
{
    [Required]
    [StringLength(50, MinimumLength = 5, ErrorMessage = "Name must be at least 5 and at max 50 characters long")]
    [UniqueUserName]
    public string? UserName { get; set; }

    [Required]
    [EmailAddress]
    [StringLength(50, MinimumLength = 5, ErrorMessage = "Email must be at least 5 and at max 50 characters long")]
    public string? Email { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 5, ErrorMessage = "Password must be at least 5 and at max 50 characters long")]
    public string? Password { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 5, ErrorMessage = "Password must be at least 5 and at max 50 characters long")]
    [Compare(nameof(Password))]
    public string? ConfirmPassword { get; set; }
}
