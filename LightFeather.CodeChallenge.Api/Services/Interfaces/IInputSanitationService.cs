using LightFeather.CodeChallenge.Domain.Dtos;

namespace LightFeather.CodeChallenge.Api.Services.Interfaces;

public interface IInputSanitationService
{
    void TrimInputFields(SubmitSupervisorDto submitSupervisorDto);
}