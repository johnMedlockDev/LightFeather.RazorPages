using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace LightFeather.Domain.Dtos;

[ExcludeFromCodeCoverage]
public class ExternalSupervisorDto
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    [Phone]
    [JsonPropertyName("phone")]
    public string Phone { get; set; } = string.Empty;

    [JsonPropertyName("jurisdiction")]
    public string Jurisdiction { get; set; } = string.Empty;

    [JsonPropertyName("identificationNumber")]
    public string IdentificationNumber { get; set; } = string.Empty;

    [JsonPropertyName("firstName")]
    public string FirstName { get; set; } = string.Empty;

    [JsonPropertyName("lastName")]
    public string LastName { get; set; } = string.Empty;
}