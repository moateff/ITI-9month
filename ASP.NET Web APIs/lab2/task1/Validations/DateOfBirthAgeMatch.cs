using System.ComponentModel.DataAnnotations;

namespace task1.Validations;

public class DateOfBirthAgeMatchAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null)
            return ValidationResult.Success;
        
        if (value is not DateOnly birthDate)
            return new ValidationResult("Invalid date format");

        int calculatedAge = CalculateAge(birthDate);
        
        var ageProperty = validationContext.ObjectType.GetProperty("Age");
        
        int inputAge = (int)ageProperty.GetValue(validationContext.ObjectInstance);

        if (inputAge != calculatedAge)
            return new ValidationResult("Date of birth and age do not match");
        
        return ValidationResult.Success;
    }

    private int CalculateAge(DateOnly birthDate)
    {
        var today = DateOnly.FromDateTime(DateTime.Today);
        int calculatedAge = today.Year - birthDate.Year;

        if (birthDate > today.AddYears(-calculatedAge))
        {
            calculatedAge--;
        }
        
        return calculatedAge;
    }
}
