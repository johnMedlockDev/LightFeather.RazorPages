using System.Diagnostics.CodeAnalysis;

namespace LightFeather.Domain.Constants;

[ExcludeFromCodeCoverage]
public class SubmitValidatorErrorConstant
{
    public const string NameErrorMessage = "Must contain no numbers, special characters, and is required.";

    public const string EmailErrorMessage = "Email must be in this format: info@company.org";

    public const string PhoneNumberErrorMessage = "Phone number must be in this format: 1 (800) 555-1234";

    public const string SupervisorErrorMessage = "Selection is required.";
}