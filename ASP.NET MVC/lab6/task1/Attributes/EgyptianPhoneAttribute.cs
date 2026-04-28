using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

public class EgyptianPhoneAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if (value == null) return false;

        string phone = value.ToString().Trim();

        var regex = new Regex(@"^(?:\+20|0020)?1[0125][0-9]{8}$");

        return regex.IsMatch(phone);
    }

    public override string FormatErrorMessage(string name)
    {
        return $"{name} must be a valid Egyptian phone number.";
    }
}