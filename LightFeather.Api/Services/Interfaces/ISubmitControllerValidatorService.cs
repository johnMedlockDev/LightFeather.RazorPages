using LightFeather.Domain.Dtos;

namespace LightFeather.Api.Services.Interfaces;

public interface ISubmitControllerValidatorService
{
    IDictionary<string,string> ValidateWithErrors(SubmitSupervisorDto submitSupervisorDto);
}