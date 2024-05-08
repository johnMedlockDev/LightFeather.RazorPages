using System.Diagnostics.CodeAnalysis;
using LightFeather.Api.Mappers;
using LightFeather.Api.Mappers.Interfaces;
using LightFeather.Api.Services;
using LightFeather.Api.Services.Interfaces;
using LightFeather.CodeChallenge.Api.Services;
using LightFeather.Infrastructure;
using LightFeather.Infrastructure.Repositories.CommandRepositories;
using LightFeather.Infrastructure.Repositories.CommandRepositories.Interfaces;
using LightFeather.Infrastructure.Repositories.QueryRepositories;
using LightFeather.Infrastructure.Repositories.QueryRepositories.Interfaces;
using LightFeather.Infrastructure.Services.Database;
using LightFeather.Infrastructure.Services.Database.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LightFeather.Api;

[ExcludeFromCodeCoverage]
public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var sqlConnectionString = Environment.GetEnvironmentVariable("SQL_CONNECTION_STRING") ?? "";
        _ = builder.Services.AddDbContextFactory<LightFeatherDbContext>(options =>
        {
            _ = options.UseSqlServer(sqlConnectionString);
        });

        #region Services

        _ = builder.Services.AddSingleton<IDatabaseInitializationService,DatabaseInitializationService>();
        _ = builder.Services.AddSingleton<ISubmitControllerValidatorService,SubmitControllerValidatorService>();
        _ = builder.Services.AddSingleton<IInputSanitationService,InputSanitationService>();

        #endregion Services

        #region Repositories

        _ = builder.Services.AddSingleton<ISubmitSupervisorCommandRepository,SubmitSupervisorCommandRepository>();
        _ = builder.Services.AddSingleton<ISubmitSupervisorQueryRepository,SubmitSupervisorQueryRepository>();

        #endregion Repositories

        #region Mappers

        _ = builder.Services.AddSingleton<ISupervisorMapper,SupervisorMapper>();
        _ = builder.Services.AddSingleton<ISubmitSupervisorMapper,SubmitSupervisorMapper>();

        #endregion Mappers

        _ = builder.Services.AddControllers();
        _ = builder.Services.AddEndpointsApiExplorer();
        _ = builder.Services.AddSwaggerGen();
        _ = builder.Services.AddHttpClient();

        var app = builder.Build();

        _ = app.UseSwagger();
        _ = app.UseSwaggerUI();
        _ = app.UseCors("AllowAnyOrigin");
        _ = app.UseHttpsRedirection();
        _ = app.UseAuthorization();
        _ = app.MapControllers();

        var dbInitializer = app.Services.GetRequiredService<IDatabaseInitializationService>();
        await dbInitializer.InitializeDatabase();

        await app.RunAsync();
    }
}