using System.Text.Json;
using LightFeather.CodeChallenge.Api.Mappers.Interfaces;
using LightFeather.CodeChallenge.Domain.Constants;
using LightFeather.CodeChallenge.Domain.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace LightFeather.CodeChallenge.Api.Controllers;

[ApiController]
[Route(LightFeatherUrlConstant.SupervisorControllerUrl)]
public class SupervisorController(ILogger<SupervisorController> logger, IHttpClientFactory httpClientFactory, ISupervisorMapper supervisorMapper) : ControllerBase
{
    private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
    private readonly ILogger<SupervisorController> _logger = logger;
    private readonly ISupervisorMapper _supervisorMapper = supervisorMapper;

    [HttpGet(Name = "GetSupervisors")]
    public IEnumerable<string> Get()
    {
        _logger.LogInformation("Getting supervisors from external source");

        var client = _httpClientFactory.CreateClient();
        var response = client.GetAsync(LightFeatherUrlConstant.SupervisorDataExternalUrl).Result;
        var content = response.Content.ReadAsStringAsync().Result;
        var externalSupervisorDtos = JsonSerializer.Deserialize<IEnumerable<ExternalSupervisorDto>>(content);
        var internalSupervisorDtos = externalSupervisorDtos is not null ? _supervisorMapper.Map(externalSupervisorDtos) : [];

        _logger.LogInformation("Returning supervisors");

        return internalSupervisorDtos
            .OrderBy(dto => dto.Jurisdiction)
            .ThenBy(dto => dto.LastName)
            .ThenBy(dto => dto.FirstName)
            .Select(dto => dto.ToString());
    }
}