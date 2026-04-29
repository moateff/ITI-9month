using System.ComponentModel.DataAnnotations;
using task1.Context;

namespace task1.Validations;

public class UniqueEmailAddressAttribute : ValidationAttribute
{
    private readonly AppDbContext _context;

    public UniqueEmailAddressAttribute()
    {
        _context = new AppDbContext();
    }

    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null)
            return ValidationResult.Success; 

        var email = value.ToString();

        // var context = (AppDbContext)validationContext.GetService(typeof(AppDbContext));

        // if (context == null)
        // {
        //     throw new InvalidOperationException("AppDbContext not registered.");
        // }

        var ssnProp = validationContext.ObjectType.GetProperty("SSN");
        
        var ssn = (int)ssnProp.GetValue(validationContext.ObjectInstance);

        var existingUser = _context.Students.Any(s => s.Email == email && s.SSN != ssn);

        if (existingUser != null)
        {
            return new ValidationResult("Email already exists");
        }

        return ValidationResult.Success;
    }
}