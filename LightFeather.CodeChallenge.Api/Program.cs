using System.Diagnostics.CodeAnalysis;
using LightFeather.CodeChallenge.Api.Mappers;
using LightFeather.CodeChallenge.Api.Mappers.Interfaces;
using LightFeather.CodeChallenge.Api.Services;
using LightFeather.CodeChallenge.Api.Services.Interfaces;
using LightFeather.CodeChallenge.Infrastructure;
using LightFeather.CodeChallenge.Infrastructure.Repositories.CommandRepositories;
using LightFeather.CodeChallenge.Infrastructure.Repositories.CommandRepositories.Interfaces;
using LightFeather.CodeChallenge.Infrastructure.Repositories.QueryRepositories;
using LightFeather.CodeChallenge.Infrastructure.Repositories.QueryRepositories.Interfaces;
using LightFeather.CodeChallenge.Infrastructure.Services.Database;
using LightFeather.CodeChallenge.Infrastructure.Services.Database.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LightFeather.CodeChallenge.Api;

[ExcludeFromCodeCoverage]
public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var sqlConnectionString = Environment.GetEnvironmentVariable("SQL_CONNECTION_STRING") ?? "";
        builder.Services.AddDbContextFactory<LightFeatherDbContext>(options => options.UseSqlServer(sqlConnectionString));

        #region Services

        builder.Services.AddSingleton<IDatabaseInitializationService, DatabaseInitializationService>();
        builder.Services.AddSingleton<ISubmitControllerValidatorService, SubmitControllerValidatorService>();
        builder.Services.AddSingleton<IInputSanitationService, InputSanitationService>();

        #endregion Services

        #region Repositories

        builder.Services.AddSingleton<ISubmitSupervisorCommandRepository, SubmitSupervisorCommandRepository>();
        builder.Services.AddSingleton<ISubmitSupervisorQueryRepository, SubmitSupervisorQueryRepository>();

        #endregion Repositories

        #region Mappers

        builder.Services.AddSingleton<ISupervisorMapper, SupervisorMapper>();
        builder.Services.AddSingleton<ISubmitSupervisorMapper, SubmitSupervisorMapper>();

        #endregion Mappers

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddHttpClient();

        var app = builder.Build();

        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseCors("AllowAnyOrigin");
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        var dbInitializer = app.Services.GetRequiredService<IDatabaseInitializationService>();
        await dbInitializer.InitializeDatabase();

        await app.RunAsync();
    }
}