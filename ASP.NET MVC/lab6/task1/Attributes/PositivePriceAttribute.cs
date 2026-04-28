using System.ComponentModel.DataAnnotations;

public class PositivePriceAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if (value == null) return false;

        if (decimal.TryParse(value.ToString(), out decimal price))
        {
            return price > 0;
        }

        return false;
    }

    public override string FormatErrorMessage(string name)
    {
        return $"{name} must be a positive value.";
    }
}