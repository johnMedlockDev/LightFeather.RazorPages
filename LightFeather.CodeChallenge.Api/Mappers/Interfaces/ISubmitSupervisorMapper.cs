using LightFeather.CodeChallenge.Domain.Dtos;
using LightFeather.CodeChallenge.Domain.Entities;

namespace LightFeather.CodeChallenge.Api.Mappers.Interfaces;

public interface ISubmitSupervisorMapper
{
    SubmitSupervisorEntity Map(SubmitSupervisorDto submitSupervisorDto);
}