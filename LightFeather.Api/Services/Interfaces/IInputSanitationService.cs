using LightFeather.Domain.Dtos;

namespace LightFeather.Api.Services.Interfaces;

public interface IInputSanitationService
{
    void TrimInputFields(SubmitSupervisorDto submitSupervisorDto);
}