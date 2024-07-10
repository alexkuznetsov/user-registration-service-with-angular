using LoginPage.Domain.Locations;
using LoginPage.Domain.UserLocations;
using LoginPage.Domain.Users;

using Microsoft.EntityFrameworkCore;

namespace LoginPage.Infrastructure.Persistence;

public class LoginPageDbContent : DbContext
{
    public LoginPageDbContent(DbContextOptions<LoginPageDbContent> options) : base(options)
    {

    }

    public DbSet<Country> Countries { get; set; } = null!;
    public DbSet<Province> Provinces { get; set; } = null!;
    public DbSet<UserLocation> UserLocations { get; set; } = null!;

    public DbSet<User> Users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfigurationsFromAssembly(typeof(LoginPageDbContent).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
