using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace LightFeather.Domain.Dtos;

[ExcludeFromCodeCoverage]
public class SubmitSupervisorDto
{
    [JsonPropertyName("firstName")]
    public string? FirstName { get; set; }

    [JsonPropertyName("lastName")]
    public string? LastName { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("phoneNumber")]
    public string? PhoneNumber { get; set; }

    [JsonPropertyName("Supervisor")]
    public string? Supervisor { get; set; }

    public override string ToString()
    {
        return $"FirstName: {FirstName} \nLastName: {LastName} \nEmail: {Email} \nPhoneNumber: {PhoneNumber} \nSupervisor: {Supervisor}";
    }
}