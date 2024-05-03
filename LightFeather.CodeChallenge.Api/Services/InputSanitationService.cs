using LightFeather.CodeChallenge.Api.Services.Interfaces;
using LightFeather.CodeChallenge.Domain.Dtos;

namespace LightFeather.CodeChallenge.Api.Services;

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