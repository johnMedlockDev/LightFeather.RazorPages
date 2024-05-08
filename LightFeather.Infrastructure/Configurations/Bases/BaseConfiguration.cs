using System.Diagnostics.CodeAnalysis;
using LightFeather.Domain.Entities.Bases;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LightFeather.Infrastructure.Configurations.Bases;

[ExcludeFromCodeCoverage]
internal abstract class BaseConfiguration
{
    protected static void ConfigureBase<T>(EntityTypeBuilder<T> entity) where T : BaseEntity<T>
    {
        _ = entity.HasKey(e => e.Id);
        _ = entity.Property(e => e.Id).ValueGeneratedOnAdd().IsRequired();

        _ = entity.Property(e => e.CreatedAt).ValueGeneratedOnAdd().IsRequired().HasDefaultValueSql("GETDATE()");
        _ = entity.Property(e => e.UpdatedAt).ValueGeneratedOnAddOrUpdate().IsRequired().HasDefaultValueSql("GETDATE()");
    }
}