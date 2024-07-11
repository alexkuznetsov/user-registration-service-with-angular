using UserPortal.Domain.Locations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UserPortal.Infrastructure.Persistence.Configurations;

internal class ProvinceConfiguration : IEntityTypeConfiguration<Province>
{
    public void Configure(EntityTypeBuilder<Province> pBuilder)
    {
        pBuilder
               .ToTable("provincies");

        pBuilder
            .HasKey(b => b.Id);

        pBuilder
            .Property(b => b.Id)
            .ValueGeneratedNever()
            .HasColumnName("id")
            .HasConversion(
                id => id.Value,
                value => ProvinceId.Create(value));


        pBuilder.Property(x => x.CreatedAt)
           .HasColumnName("created_at")
           .IsRequired();

        pBuilder.Property(x => x.Name)
            .HasColumnName("name")
            .HasMaxLength(256)
            .IsRequired();

        pBuilder.HasOne(x => x.Country)
            .WithMany()
            .HasForeignKey("country_id")
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
    }
}
