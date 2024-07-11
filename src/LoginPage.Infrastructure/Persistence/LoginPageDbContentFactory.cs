using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace LoginPage.Infrastructure.Persistence;

public class LoginPageDbContentFactory : IDesignTimeDbContextFactory<LoginPageDbContext>
{
    public LoginPageDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<LoginPageDbContext>();
        optionsBuilder.UseSqlite($"Data Source=loginpage.db");

        return new LoginPageDbContext(optionsBuilder.Options);
    }
}
