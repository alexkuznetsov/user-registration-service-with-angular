using UserPortal.Domain.Locations;
using UserPortal.Domain.Users;

using Microsoft.EntityFrameworkCore;

namespace UserPortal.Infrastructure.Persistence;

public class UserPortalDbContext : DbContext
{
    public UserPortalDbContext(DbContextOptions<UserPortalDbContext> options) : base(options)
    {

    }

    public DbSet<Country> Countries { get; set; } = null!;
    public DbSet<Province> Provinces { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfigurationsFromAssembly(typeof(UserPortalDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
