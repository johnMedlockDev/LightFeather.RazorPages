using System.Diagnostics.CodeAnalysis;

namespace LightFeather.CodeChallenge.Domain.Entities.Bases;

[ExcludeFromCodeCoverage]
public abstract class BaseEntity<T>
{
    public DateTime CreatedAt { get; set; }
    public long Id { get; set; }
    public DateTime UpdatedAt { get; set; }
}