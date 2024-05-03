using LightFeather.CodeChallenge.Domain.Dtos;

namespace LightFeather.CodeChallenge.Api.Services.Interfaces;

public interface ISubmitControllerValidatorService
{
    IDictionary<string, string> ValidateWithErrors(SubmitSupervisorDto submitSupervisorDto);
}