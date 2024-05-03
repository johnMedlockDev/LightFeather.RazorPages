using LightFeather.CodeChallenge.Api.Mappers.Interfaces;
using LightFeather.CodeChallenge.Domain.Dtos;

namespace LightFeather.CodeChallenge.Api.Mappers;

public class SupervisorMapper : ISupervisorMapper
{
    public IEnumerable<InternalSupervisorDto> Map(IEnumerable<ExternalSupervisorDto> externalSupervisorDto)
    {
        return externalSupervisorDto.Select(Map);
    }

    public InternalSupervisorDto Map(ExternalSupervisorDto externalSupervisorDto)
    {
        return new InternalSupervisorDto
        {
            Jurisdiction = externalSupervisorDto.Jurisdiction,
            FirstName = externalSupervisorDto.FirstName,
            LastName = externalSupervisorDto.LastName
        };
    }
}