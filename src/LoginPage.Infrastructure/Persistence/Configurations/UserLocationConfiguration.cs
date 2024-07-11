using LoginPage.Domain.Locations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoginPage.Infrastructure.Persistence.Configurations;

internal class UserLocationConfiguration : IEntityTypeConfiguration<UserLocation>
{
    public void Configure(EntityTypeBuilder<UserLocation> lBuilder)
    {
        lBuilder
            .ToTable("user_locations");

        lBuilder
            .HasKey(b => b.Id);

        lBuilder.Property(x => x.CreatedAt)
            .HasColumnName("created_at");

        lBuilder
            .Property(b => b.Id)
            .HasColumnName("id")
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => UserLocationId.Create(value));

        lBuilder.HasOne(x => x.Province)
          .WithMany()
          .HasForeignKey("province_id")
          .OnDelete(DeleteBehavior.Cascade)
          .IsRequired();

        lBuilder.HasOne(x => x.User)
           .WithMany()
           .HasForeignKey("user_id")
           .OnDelete(DeleteBehavior.Cascade)
           .IsRequired();
    }
}
