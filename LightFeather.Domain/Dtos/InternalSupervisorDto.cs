using System.Diagnostics.CodeAnalysis;

namespace LightFeather.Domain.Dtos;

[ExcludeFromCodeCoverage]
public class InternalSupervisorDto
{
    public string Jurisdiction { get; set; } = string.Empty;

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public override string ToString()
    {
        return $"{RemoveJurisdictionWhenNumeric()} - {LastName}, {FirstName}";
    }

    private string RemoveJurisdictionWhenNumeric()
    {
        return Jurisdiction.All(char.IsDigit) ? "" : Jurisdiction;
    }
}