using System.Diagnostics.CodeAnalysis;

namespace LightFeather.Domain.Dtos;

[ExcludeFromCodeCoverage]
public class SelectionSupervisorDto
{
    public required string SupervisorString { get; set; }
}