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
        return Ok();
    }
}