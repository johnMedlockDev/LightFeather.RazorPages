using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace LightFeather.CodeChallenge.Infrastructure.Factories;

[ExcludeFromCodeCoverage]
public sealed class LightFeatherDbContextFactory : IDesignTimeDbContextFactory<LightFeatherDbContext>
{
    public LightFeatherDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<LightFeatherDbContext>();

        var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        var envConnectionString = Environment.GetEnvironmentVariable("SQL_CONNECTION_STRING");

        optionsBuilder.UseSqlServer(String.IsNullOrEmpty(envConnectionString) ? connectionString : envConnectionString,
            opts =>
            {
                opts.CommandTimeout((int) TimeSpan.FromMinutes(5).TotalSeconds);
            });

        return new LightFeatherDbContext(optionsBuilder.Options);
    }
}