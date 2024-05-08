using LightFeather.Domain.Dtos;
using LightFeather.Domain.Entities;

namespace LightFeather.Api.Mappers.Interfaces;

public interface ISubmitSupervisorMapper
{
    SubmitSupervisorEntity Map(SubmitSupervisorDto submitSupervisorDto);
}