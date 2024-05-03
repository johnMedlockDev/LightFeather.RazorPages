using System.Diagnostics.CodeAnalysis;

namespace LightFeather.CodeChallenge.Domain.Constants;

[ExcludeFromCodeCoverage]
public class LightFeatherUrlConstant
{
    public const string ApiBaseUrl = "http://api:8080";
    public const string SupervisorControllerUrl = $"api/supervisors";
    public const string SubmitControllerUrl = $"api/submit";
    public const string SupervisorDataExternalUrl = "https://o3m5qixdng.execute-api.us-east-1.amazonaws.com/api/managers";
}