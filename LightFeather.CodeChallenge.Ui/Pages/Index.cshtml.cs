using System.Text.Json;
using LightFeather.CodeChallenge.Domain.Constants;
using LightFeather.CodeChallenge.Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LightFeather.CodeChallenge.Ui.Pages;

public class IndexModel(ILogger<IndexModel> logger, IHttpClientFactory clientFactory) : PageModel
{
    private readonly ILogger<IndexModel> _logger = logger;
    private readonly IHttpClientFactory _clientFactory = clientFactory;

    [BindProperty]
    public string? FirstName { get; set; }

    [BindProperty]
    public string? LastName { get; set; }

    [BindProperty]
    public bool EmailCheckBox { get; set; }

    [BindProperty]
    public string? Email { get; set; }

    [BindProperty]
    public bool PhoneCheckBox { get; set; }

    [BindProperty]
    public string? PhoneNumber { get; set; }

    [BindProperty]
    public string? Supervisor { get; set; }

    public List<SelectionSupervisorDto> Supervisors { get; set; } = [];

    public async Task OnGetAsync()
    {
        _logger.LogInformation("Getting supervisors");
        var client = _clientFactory.CreateClient();
        client.BaseAddress = new Uri(LightFeatherUrlConstant.ApiBaseUrl);
        await PopulateSupervisorSelection(client);
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (EmailCheckBox && Email is null)
        {
            Email = String.Empty;
        }

        if (PhoneCheckBox && PhoneNumber is null)
        {
            PhoneNumber = String.Empty;
        }

        var submission = new SubmitSupervisorDto
        {
            FirstName = FirstName,
            LastName = LastName,
            Email = Email,
            PhoneNumber = PhoneNumber,
            Supervisor = Supervisor
        };

        var client = _clientFactory.CreateClient();
        client.BaseAddress = new Uri(LightFeatherUrlConstant.ApiBaseUrl);
        var response = await client.PostAsJsonAsync(LightFeatherUrlConstant.SubmitControllerUrl, submission);

        if (!response.IsSuccessStatusCode)
        {
            var errorResponse = await response.Content.ReadAsStringAsync();
            try
            {
                var problemDetails = JsonSerializer.Deserialize<ValidationProblemDetails>(errorResponse);

                if (problemDetails?.Errors != null)
                {
                    foreach (var error in problemDetails.Errors)
                    {
                        foreach (var detail in error.Value)
                        {
                            ModelState.AddModelError(error.Key, detail);
                        }
                    }
                }

                _logger.LogError("API error: {ErrorResponse}", errorResponse);
                ModelState.AddModelError("", $"API error: {problemDetails?.Detail}");
            }
            catch (JsonException ex)
            {
                _logger.LogError(ex, "Error deserializing the API error response.");
                ModelState.AddModelError("", "An unexpected error occurred.");
            }
            await PopulateSupervisorSelection(client);
            return Page();
        }

        ModelState.Clear();
        ClearFormData();

        await PopulateSupervisorSelection(client);

        TempData["SuccessMessage"] = "Submission successful";
        return RedirectToPage();
    }

    private void ClearFormData()
    {
        FirstName = null;
        LastName = null;
        Email = null;
        PhoneNumber = null;
        Supervisor = null;
        EmailCheckBox = false;
        PhoneCheckBox = false;
    }

    private async Task PopulateSupervisorSelection(HttpClient client)
    {
        var response = await client.GetAsync(LightFeatherUrlConstant.SupervisorControllerUrl);
        if (response.IsSuccessStatusCode)
        {
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var supervisorStringValues = JsonSerializer.Deserialize<List<string>>(jsonResponse);

            Supervisors = supervisorStringValues?.Select(supervisorStringValue => new SelectionSupervisorDto { SupervisorString = supervisorStringValue }).ToList() ?? [];

            _logger.LogInformation("Supervisors retrieved successfully.");
        }
    }
}