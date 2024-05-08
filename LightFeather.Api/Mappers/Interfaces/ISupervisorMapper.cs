using LightFeather.Domain.Dtos;

namespace LightFeather.Api.Mappers.Interfaces;

public interface ISupervisorMapper
{
    IEnumerable<InternalSupervisorDto> Map(IEnumerable<ExternalSupervisorDto> externalSupervisorDto);

    InternalSupervisorDto Map(ExternalSupervisorDto externalSupervisorDto);
}