using LoginPage.Domain.Locations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoginPage.Infrastructure.Persistence.Configurations;

internal class ProvinceConfiguration : IEntityTypeConfiguration<Province>
{
    public void Configure(EntityTypeBuilder<Province> builder)
    {
        ConfigureProvinceTable(builder);
    }

    private static void ConfigureProvinceTable(EntityTypeBuilder<Province> builder)
    {
        builder
            .ToTable("provincies");

        builder
            .HasKey(b => b.Id);

        builder
            .Property(b => b.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => ProvinceId.Create(value));
    }
}
