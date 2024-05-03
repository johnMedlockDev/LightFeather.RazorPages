using LightFeather.CodeChallenge.Domain.Dtos;

namespace LightFeather.CodeChallenge.Api.Mappers.Interfaces;

public interface ISupervisorMapper
{
    IEnumerable<InternalSupervisorDto> Map(IEnumerable<ExternalSupervisorDto> externalSupervisorDto);

    InternalSupervisorDto Map(ExternalSupervisorDto externalSupervisorDto);
}