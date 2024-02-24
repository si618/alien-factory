namespace AlienFactory;

using System.ComponentModel.DataAnnotations;
using System.Net;

public class ValidIpAddressAttribute : ValidationAttribute
{
    private string Error => ResourceBuilder
        .GetResource(nameof(ValidIpAddressAttribute), nameof(Error));

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is string strValue && IPAddress.TryParse(strValue, out _))
        {
            return ValidationResult.Success;
        }

        return new ValidationResult(Error);
    }
}
