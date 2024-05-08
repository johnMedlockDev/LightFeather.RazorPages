using LightFeather.Domain.Entities;
using LightFeather.Infrastructure.Configurations.Bases;
using Microsoft.EntityFrameworkCore;

namespace LightFeather.Infrastructure.Configurations;

internal sealed class SubmitSupervisorConfiguration : BaseConfiguration
{
    public static void Configure(ModelBuilder modelBuilder)
    {
        _ = modelBuilder.Entity<SubmitSupervisorEntity>(entity =>
        {
            ConfigureBase(entity);

            _ = entity.Property(e => e.FirstName).IsRequired().HasMaxLength(50).IsRequired();
            _ = entity.Property(e => e.LastName).IsRequired().HasMaxLength(50).IsRequired();
            _ = entity.Property(e => e.Email).HasMaxLength(100).IsRequired(false);
            _ = entity.Property(e => e.PhoneNumber).HasMaxLength(50).IsRequired(false);
            _ = entity.Property(e => e.Supervisor).IsRequired().HasMaxLength(250).IsRequired();
        });
    }
}