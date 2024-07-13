using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;

using UserPortal.Infrastructure.Persistence;

namespace UserPortal.IntergrationTests.Configuration;

public class UpTestWebApplicationFactory<TProgram>
    : WebApplicationFactory<TProgram> where TProgram : class
{
    protected override IHost CreateHost(IHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<UserPortalDbContext>));

            if (descriptor != null)
            {
                services.Remove(descriptor);
            }

            services.AddDbContext<UserPortalDbContext>(options =>
            {
                var ds = Path.Join(Environment.CurrentDirectory, "UserPortalDb_tests.db");

                options.UseSqlite($"Data Source={ds}");
            });
        });

        return base.CreateHost(builder);
    }
}
