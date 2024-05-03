using System.Diagnostics.CodeAnalysis;

namespace LightFeather.CodeChallenge.Domain.Dtos;

[ExcludeFromCodeCoverage]
public class SelectionSupervisorDto
{
    public required string SupervisorString { get; set; }
}