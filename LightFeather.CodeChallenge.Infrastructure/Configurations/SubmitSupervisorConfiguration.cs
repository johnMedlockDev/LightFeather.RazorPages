using LightFeather.CodeChallenge.Domain.Entities;
using LightFeather.CodeChallenge.Infrastructure.Configurations.Bases;
using Microsoft.EntityFrameworkCore;

namespace LightFeather.CodeChallenge.Infrastructure.Configurations;

internal sealed class SubmitSupervisorConfiguration : BaseConfiguration
{
    public static void Configure(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SubmitSupervisorEntity>(entity =>
        {
            ConfigureBase(entity);

            entity.Property(e => e.FirstName).IsRequired().HasMaxLength(50).IsRequired();
            entity.Property(e => e.LastName).IsRequired().HasMaxLength(50).IsRequired();
            entity.Property(e => e.Email).HasMaxLength(100).IsRequired(false);
            entity.Property(e => e.PhoneNumber).HasMaxLength(50).IsRequired(false);
            entity.Property(e => e.Supervisor).IsRequired().HasMaxLength(250).IsRequired();
        });
    }
}