using LightFeather.Api.Mappers.Interfaces;
using LightFeather.Domain.Dtos;
using LightFeather.Domain.Entities;

namespace LightFeather.Api.Mappers;

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