namespace LightFeather.Infrastructure.Services.Database.Interfaces;

public interface IDatabaseInitializationService
{
    Task InitializeDatabase();
}