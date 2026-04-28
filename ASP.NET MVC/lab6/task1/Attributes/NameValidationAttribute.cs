using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

public class NameValidationAttribute : ValidationAttribute
{
    private readonly int _min;
    private readonly int _max;

    public NameValidationAttribute(int min = 2, int max = 50)
    {
        _min = min;
        _max = max;
    }

    public override bool IsValid(object? value)
    {
        if (value == null) return false;

        string pattern = $@"^[A-Za-z\s]{{{_min},{_max}}}$";
        return Regex.IsMatch(value.ToString(), pattern);
    }

    public override string FormatErrorMessage(string name)
    {
        return $"{name} must contains only letters and spaces.";
    }
}