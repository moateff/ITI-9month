using System.ComponentModel.DataAnnotations;

namespace task1.ViewModels;

public class RegisterViewModel
{
    [Key]
    public int Id { get; set; }

    [Required]
    [Display(Name = "User Name")]
    [StringLength(100, MinimumLength = 2)]
    public string UserName { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [StringLength(100, MinimumLength = 6)]
    public string Password { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Compare("Password")]
    [Display(Name = "Confirm password")]
    [StringLength(100, MinimumLength = 6)]
    public string ConfirmPassword { get; set; }

    [Required]
    [EmailAddress]
    [Display(Name = "Email")]
    public string Email { get; set; }

    [Required]
    [Display(Name = "First Name")]
    [StringLength(100, MinimumLength = 2)]
    public string FirstName { get; set; }

    [Required]
    [Display(Name = "Last Name")]
    [StringLength(100, MinimumLength = 2)]
    public string LastName { get; set; }
}