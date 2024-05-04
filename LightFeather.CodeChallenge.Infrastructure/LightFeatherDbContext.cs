using System.Diagnostics.CodeAnalysis;
using LightFeather.CodeChallenge.Domain.Entities;
using LightFeather.CodeChallenge.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace LightFeather.CodeChallenge.Infrastructure;

[ExcludeFromCodeCoverage]
public sealed class LightFeatherDbContext(DbContextOptions<LightFeatherDbContext> options) : DbContext(options)
{
    public DbSet<SubmitSupervisorEntity> SubmitSupervisorEntities { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        SubmitSupervisorConfiguration.Configure(modelBuilder);
    }
}