using System.Diagnostics.CodeAnalysis;
using LightFeather.Domain.Entities;
using LightFeather.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace LightFeather.Infrastructure;

[ExcludeFromCodeCoverage]
public sealed class LightFeatherDbContext(DbContextOptions<LightFeatherDbContext> options) : DbContext(options)
{
    public DbSet<SubmitSupervisorEntity> SubmitSupervisorEntities { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        SubmitSupervisorConfiguration.Configure(modelBuilder);
    }
}