using LightFeather.CodeChallenge.Api.Mappers.Interfaces;
using LightFeather.CodeChallenge.Domain.Dtos;
using LightFeather.CodeChallenge.Domain.Entities;

namespace LightFeather.CodeChallenge.Api.Mappers;

public class SubmitSupervisorMapper : ISubmitSupervisorMapper
{
    public SubmitSupervisorEntity Map(SubmitSupervisorDto submitSupervisorDto)
    {
        return new SubmitSupervisorEntity
        {
            FirstName = submitSupervisorDto.FirstName!,
            LastName = submitSupervisorDto.LastName!,
            Email = submitSupervisorDto.Email,
            PhoneNumber = submitSupervisorDto.PhoneNumber,
            Supervisor = submitSupervisorDto.Supervisor!
        };
    }
}