using System.ComponentModel.DataAnnotations;

namespace task1.ViewModels;

public class LoginViewModel
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

    public bool RememberMe { get; set; }
}