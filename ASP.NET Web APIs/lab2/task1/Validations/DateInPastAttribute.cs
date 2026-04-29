using System.ComponentModel.DataAnnotations;

namespace task1.Validations;

public class DateInPastAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if (value == null)
            return true;
        
        if (value is not DateOnly date)
            return false;

        return date <= DateOnly.FromDateTime(DateTime.Today);
    }

    public override string FormatErrorMessage(string name)
    {
        return $"{name} must be in the past.";
    }
}