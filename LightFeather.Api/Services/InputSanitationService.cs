using LightFeather.Api.Services.Interfaces;
using LightFeather.Domain.Dtos;

namespace LightFeather.Api.Services;

public class InputSanitationService : IInputSanitationService
{
    public void TrimInputFields(SubmitSupervisorDto submitSupervisorDto)
    {
        submitSupervisorDto.FirstName = submitSupervisorDto.FirstName?.Trim();
        submitSupervisorDto.LastName = submitSupervisorDto.LastName?.Trim();
        submitSupervisorDto.Email = submitSupervisorDto.Email?.Trim();
        submitSupervisorDto.PhoneNumber = submitSupervisorDto.PhoneNumber?.Trim();
        submitSupervisorDto.Supervisor = submitSupervisorDto.Supervisor?.Trim();
    }
}