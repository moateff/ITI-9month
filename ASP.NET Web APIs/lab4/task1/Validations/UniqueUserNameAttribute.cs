using System.ComponentModel.DataAnnotations;
using task1.Context;

namespace task1.Validations;

public class UniqueUserNameAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null)
            return ValidationResult.Success;

        var name = value.ToString();

        var context = (AppDbContext)validationContext.GetService(typeof(AppDbContext))?? throw new InvalidOperationException();

        var existingUser = context.Users.Any(s => s.UserName == name);

        if (existingUser == true)
        {
            return new ValidationResult("User name already exists");
        }

        return ValidationResult.Success;
    }
}