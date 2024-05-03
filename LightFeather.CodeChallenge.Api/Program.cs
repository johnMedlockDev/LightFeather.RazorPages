using LightFeather.CodeChallenge.Api.Mappers;
using LightFeather.CodeChallenge.Api.Mappers.Interfaces;
using LightFeather.CodeChallenge.Api.Services;
using LightFeather.CodeChallenge.Api.Services.Interfaces;

namespace LightFeather.CodeChallenge.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddHttpClient();

        builder.Services.AddScoped<ISupervisorMapper, SupervisorMapper>();
        builder.Services.AddScoped<ISubmitControllerValidatorService, SubmitControllerValidatorService>();
        builder.Services.AddScoped<IInputSanitationService, InputSanitationService>();

        var app = builder.Build();

        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseCors("AllowAnyOrigin");

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}