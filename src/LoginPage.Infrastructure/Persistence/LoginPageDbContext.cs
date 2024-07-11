using LoginPage.Domain.Locations;
using LoginPage.Domain.Users;

using Microsoft.EntityFrameworkCore;

namespace LoginPage.Infrastructure.Persistence;

public class LoginPageDbContext : DbContext
{
    public LoginPageDbContext(DbContextOptions<LoginPageDbContext> options) : base(options)
    {

    }

    public DbSet<Country> Countries { get; set; } = null!;
    public DbSet<Province> Provinces { get; set; } = null!;
    public DbSet<UserLocation> UserLocations { get; set; } = null!;

    public DbSet<User> Users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfigurationsFromAssembly(typeof(LoginPageDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
