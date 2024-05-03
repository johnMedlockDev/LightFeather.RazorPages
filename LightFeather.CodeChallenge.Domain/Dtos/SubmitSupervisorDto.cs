using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace LightFeather.CodeChallenge.Domain.Dtos;

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
}