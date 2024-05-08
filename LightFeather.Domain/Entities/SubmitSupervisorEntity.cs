using LightFeather.Domain.Entities.Bases;

namespace LightFeather.Domain.Entities;

public class SubmitSupervisorEntity : BaseEntity<SubmitSupervisorEntity>
{
    public required string FirstName { get; set; }

    public required string LastName { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public required string Supervisor { get; set; }
}