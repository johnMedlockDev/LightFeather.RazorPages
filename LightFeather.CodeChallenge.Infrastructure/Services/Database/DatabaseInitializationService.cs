using LightFeather.CodeChallenge.Infrastructure.Services.Database.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LightFeather.CodeChallenge.Infrastructure.Services.Database;

public sealed class DatabaseInitializationService(IServiceProvider serviceProvider) : IDatabaseInitializationService
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;

    public async Task InitializeDatabase()
    {
        await using var scope = _serviceProvider.CreateAsyncScope();
        var serviceProvider = scope.ServiceProvider;
        var dbContext = serviceProvider.GetRequiredService<LightFeatherDbContext>();

        try
        {
            var pendingMigrations = await dbContext.Database.GetPendingMigrationsAsync();

            if (pendingMigrations.Any())
            {
                await dbContext.Database.MigrateAsync();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}