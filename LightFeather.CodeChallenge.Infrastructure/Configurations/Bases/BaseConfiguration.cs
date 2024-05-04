using System.Diagnostics.CodeAnalysis;
using LightFeather.CodeChallenge.Domain.Entities.Bases;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LightFeather.CodeChallenge.Infrastructure.Configurations.Bases;

[ExcludeFromCodeCoverage]
internal abstract class BaseConfiguration
{
    protected static void ConfigureBase<T>(EntityTypeBuilder<T> entity) where T : BaseEntity<T>
    {
        entity.HasKey(e => e.Id);
        entity.Property(e => e.Id).ValueGeneratedOnAdd().IsRequired();

        entity.Property(e => e.CreatedAt).ValueGeneratedOnAdd().IsRequired().HasDefaultValueSql("GETDATE()");
        entity.Property(e => e.UpdatedAt).ValueGeneratedOnAddOrUpdate().IsRequired().HasDefaultValueSql("GETDATE()");
    }
}