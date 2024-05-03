using System.Diagnostics.CodeAnalysis;

namespace LightFeather.CodeChallenge.Domain.Dtos;

[ExcludeFromCodeCoverage]
public class InternalSupervisorDto
{
    public string Jurisdiction { get; set; } = String.Empty;

    public string FirstName { get; set; } = String.Empty;

    public string LastName { get; set; } = String.Empty;

    public override string ToString()
    {
        return $"{RemoveJurisdictionWhenNumeric()} - {LastName}, {FirstName}";
    }

    private string RemoveJurisdictionWhenNumeric()
    {
        return Jurisdiction.All(Char.IsDigit) ? "" : Jurisdiction;
    }
}