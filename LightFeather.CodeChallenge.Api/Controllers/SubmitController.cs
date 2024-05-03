using LightFeather.CodeChallenge.Api.Services.Interfaces;
using LightFeather.CodeChallenge.Domain.Constants;
using LightFeather.CodeChallenge.Domain.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace LightFeather.CodeChallenge.Api.Controllers;

[ApiController]
[Route(LightFeatherUrlConstant.SubmitControllerUrl)]
public class SubmitController(ILogger<SubmitController> logger, IInputSanitationService inputSanitationService, ISubmitControllerValidatorService submitControllerValidatorService) : ControllerBase
{
    private readonly ILogger<SubmitController> _logger = logger;
    private readonly ISubmitControllerValidatorService _submitControllerValidatorService = submitControllerValidatorService;

    [HttpPost(Name = "PostSubmit")]
    public IActionResult Post(SubmitSupervisorDto submitSupervisorDto)
    {
        inputSanitationService.TrimInputFields(submitSupervisorDto);

        _logger.LogInformation("Received submission for supervisor: {FirstName} {LastName}", submitSupervisorDto.FirstName, submitSupervisorDto.LastName);

        var errors = _submitControllerValidatorService.ValidateWithErrors(submitSupervisorDto);

        if (errors.Any())
        {
            _logger.LogInformation("Submission is Invalid");

            foreach (var kvp in errors)
            {
                ModelState.AddModelError(kvp.Key, kvp.Value);
            }

            return BadRequest(new ValidationProblemDetails(ModelState)
            {
                Status = 400,
                Title = "Validation Error",
                Detail = "See the errors property for more details."
            });
        }

        _logger.LogInformation("Submission is valid");
        _logger.LogInformation("FirstName: {FirstName}", submitSupervisorDto.FirstName);
        _logger.LogInformation("LastName: {LastName}", submitSupervisorDto.LastName);
        _logger.LogInformation("Email: {Email}", submitSupervisorDto.Email);
        _logger.LogInformation("PhoneNumber: {PhoneNumber}", submitSupervisorDto.PhoneNumber);
        _logger.LogInformation("Supervisor: {Supervisor}", submitSupervisorDto.Supervisor);
        return Ok();
    }
}