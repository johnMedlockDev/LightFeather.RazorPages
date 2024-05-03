using System.Text.RegularExpressions;
using LightFeather.CodeChallenge.Api.Services.Interfaces;
using LightFeather.CodeChallenge.Domain.Constants;
using LightFeather.CodeChallenge.Domain.Dtos;

namespace LightFeather.CodeChallenge.Api.Services;

public partial class SubmitControllerValidatorService : ISubmitControllerValidatorService
{
    private static readonly Regex EmailRegex = EmailGeneratedRegex();

    private static readonly Regex PhoneRegex = PhoneGeneratedRegex();

    public IDictionary<string, string> ValidateWithErrors(SubmitSupervisorDto submitSupervisorDto)
    {
        var errors = new Dictionary<string, string>();

        if (!IsValidFirstName(submitSupervisorDto.FirstName))
        {
            errors.Add(nameof(submitSupervisorDto.FirstName), SubmitValidatorErrorConstant.NameErrorMessage);
        }

        if (!IsValidLastName(submitSupervisorDto.LastName))
        {
            errors.Add(nameof(submitSupervisorDto.LastName), SubmitValidatorErrorConstant.NameErrorMessage);
        }

        if (!IsValidEmail(submitSupervisorDto.Email))
        {
            errors.Add(nameof(submitSupervisorDto.Email), SubmitValidatorErrorConstant.EmailErrorMessage);
        }

        if (!IsValidPhoneNumber(submitSupervisorDto.PhoneNumber))
        {
            errors.Add(nameof(submitSupervisorDto.PhoneNumber), SubmitValidatorErrorConstant.PhoneNumberErrorMessage);
        }

        if (String.IsNullOrEmpty(submitSupervisorDto.Supervisor))
        {
            errors.Add(nameof(submitSupervisorDto.Supervisor), SubmitValidatorErrorConstant.SupervisorErrorMessage);
        }

        return errors;
    }

    [GeneratedRegex(@"^\s*(?:\+?(\d{1,3}))?[-. (]*(\d{3})[-. )]*(\d{3})[-. ]*(\d{4})(?: *x(\d+))?\s*$", RegexOptions.Compiled)]
    private static partial Regex PhoneGeneratedRegex();

    [GeneratedRegex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase | RegexOptions.Compiled, "en-US")]
    private static partial Regex EmailGeneratedRegex();

    private static bool IsValidEmail(string? email)
    {
        return email is null || (EmailRegex.IsMatch(email) && email is not "");
    }

    private static bool IsValidPhoneNumber(string? phoneNumber)
    {
        return phoneNumber is null || (PhoneRegex.IsMatch(phoneNumber) && phoneNumber is not "");
    }

    private static bool IsNotNullOrEmpty(string? value)
    {
        return !String.IsNullOrEmpty(value);
    }

    private static bool HasNoSpecialCharactersOrNumbers(string value)
    {
        return !value.Any(Char.IsDigit) && !value.Any(Char.IsPunctuation);
    }

    private static bool IsValidFirstName(string? firstName)
    {
        return IsNotNullOrEmpty(firstName) && HasNoSpecialCharactersOrNumbers(firstName!);
    }

    private static bool IsValidLastName(string? lastName)
    {
        return IsNotNullOrEmpty(lastName) && HasNoSpecialCharactersOrNumbers(lastName!);
    }
}