using LightFeather.Api.Mappers.Interfaces;
using LightFeather.Api.Services.Interfaces;
using LightFeather.Domain.Constants;
using LightFeather.Domain.Dtos;
using LightFeather.Infrastructure.Repositories.CommandRepositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LightFeather.Api.Controllers;

[ApiController]
[Route(LightFeatherUrlConstant.SubmitControllerUrl)]
public class SubmitController(ILogger<SubmitController> logger,IInputSanitationService inputSanitationService,ISubmitControllerValidatorService submitControllerValidatorService,ISubmitSupervisorCommandRepository submitSupervisorCommandRepository,ISubmitSupervisorMapper submitSupervisorMapper) : ControllerBase
{
    private readonly ILogger<SubmitController> _logger = logger;

    private readonly ISubmitControllerValidatorService _submitControllerValidatorService = submitControllerValidatorService;

    private readonly IInputSanitationService _inputSanitationService = inputSanitationService;

    private readonly ISubmitSupervisorCommandRepository _submitSupervisorCommandRepository = submitSupervisorCommandRepository;

    private readonly ISubmitSupervisorMapper _submitSupervisorMapper = submitSupervisorMapper;

    [HttpPost(Name = "PostSubmit")]
    public async Task<IActionResult> PostAsync(SubmitSupervisorDto submitSupervisorDto)
    {
        _inputSanitationService.TrimInputFields(submitSupervisorDto);

        _logger.LogInformation("Received submission for supervisor: {FirstName} {LastName}",submitSupervisorDto.FirstName,submitSupervisorDto.LastName);

        var errors = _submitControllerValidatorService.ValidateWithErrors(submitSupervisorDto);

        if (errors.Any())
        {
            _logger.LogInformation("Submission is Invalid");

            foreach (var kvp in errors)
            {
                ModelState.AddModelError(kvp.Key,kvp.Value);
            }

            return BadRequest(new ValidationProblemDetails(ModelState)
            {
                Status = 400,
                Title = "Validation Error",
                Detail = "See the errors property for more details."
            });
        }

        _logger.LogInformation("Submission is valid");
        _logger.LogInformation("\nSubmitSupervisorDto: \n{submitSupervisorDto}\n",submitSupervisorDto.ToString());

        var entity = _submitSupervisorMapper.Map(submitSupervisorDto);
        await _submitSupervisorCommandRepository.AddAsync(entity);

        return Ok();
    }
}