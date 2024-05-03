using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace LightFeather.CodeChallenge.Domain.Dtos;

[ExcludeFromCodeCoverage]
public class ExternalSupervisorDto
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = String.Empty;

    [Phone]
    [JsonPropertyName("phone")]
    public string Phone { get; set; } = String.Empty;

    [JsonPropertyName("jurisdiction")]
    public string Jurisdiction { get; set; } = String.Empty;

    [JsonPropertyName("identificationNumber")]
    public string IdentificationNumber { get; set; } = String.Empty;

    [JsonPropertyName("firstName")]
    public string FirstName { get; set; } = String.Empty;

    [JsonPropertyName("lastName")]
    public string LastName { get; set; } = String.Empty;
}