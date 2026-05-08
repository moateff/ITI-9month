using System.ComponentModel.DataAnnotations;
using task1.Context;

namespace task1.Validations;

public class UniqueDepartmentNameAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null)
            return ValidationResult.Success; 

        var name = value.ToString();

        var idProp = validationContext.ObjectType.GetProperty("Id");
        
        var id = (int)idProp.GetValue(validationContext.ObjectInstance);

        var context = (AppDbContext)validationContext.GetService(typeof(AppDbContext))?? throw new InvalidOperationException();

        var found = context.Departments.Any(d => d.Name == name && d.Id != id);

        if (found == true)
        {
            return new ValidationResult("Department name already exists");
        }

        return ValidationResult.Success;
    }
}