using LoginPage.Domain.Users;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoginPage.Infrastructure.Persistence.Configurations;

internal class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .ToTable("users");

        builder
            .HasKey(b => b.Id);

        builder
            .Property(b => b.Id)
            .HasColumnName("id")
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => UserId.Create(value));

        builder.Property(x => x.CreatedAt)
           .HasColumnName("created_at");

        builder.Property(x => x.Email)
                   .HasColumnName("email")
                   .HasMaxLength(256);

        builder.Property(x => x.Password)
                   .HasColumnName("password")
                   .HasMaxLength(256);

        builder.HasOne(x => x.Province)
            .WithMany()
            .HasForeignKey("province_id")
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
    }
}
