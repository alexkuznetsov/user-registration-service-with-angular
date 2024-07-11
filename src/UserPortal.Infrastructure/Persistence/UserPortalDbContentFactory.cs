using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace UserPortal.Infrastructure.Persistence;

public class UserPortalDbContentFactory : IDesignTimeDbContextFactory<UserPortalDbContext>
{
    public UserPortalDbContext CreateDbContext(string[] args)
    {
        var basePath = Directory.GetParent(Directory.GetCurrentDirectory())!.FullName!;
        var location = Path.Combine(basePath, "UserPortal");

        Console.WriteLine($"Base path: {location}");

        var config = new ConfigurationBuilder()
            .SetBasePath(location)
            .AddJsonFile("appsettings.json")
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<UserPortalDbContext>();
        optionsBuilder.UseSqlite(config.GetConnectionString("DefaultEntities"));

        return new UserPortalDbContext(optionsBuilder.Options);
    }
}
