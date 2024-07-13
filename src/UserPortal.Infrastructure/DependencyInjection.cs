using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using UserPortal.Application.Common.Authentication;
using UserPortal.Application.Common.Persistance;
using UserPortal.Application.Common.Services;
using UserPortal.Domain.Users;
using UserPortal.Infrastructure.Authentication;
using UserPortal.Infrastructure.Persistence;
using UserPortal.Infrastructure.Persistence.Repositories;
using UserPortal.Infrastructure.Services;

namespace UserPortal.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOptions();
        services.ConfigureOptions<JwtAuthenticationSettingsSetup>();
        services.AddSingleton<IClock, UtcClock>();
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        services.AddAuthorization();
        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer();

        services.ConfigureOptions<JwtBearerOptionsSetup>();

        services.ConfigureOptions<PasswordHasherOptionsSetup>();
        services.AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>();

        services.AddPersistence(configuration);

        return services;
    }

    private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<UserPortalDbContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("DefaultEntities")));

        services.AddScoped<ICountriesRepository, CountriesRepository>();
        services.AddScoped<IProvincesRepository, ProvincesRepository>();
        services.AddScoped<IUsersRepository, UsersRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddOptions<DataSeederOptions>();
        services.Configure<DataSeederOptions>(configuration.GetSection("DataSeed"));
        services.AddScoped<DataSeeder>();

        return services;
    }

    public static WebApplication UseDatabaseMigrator(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var ctx = scope.ServiceProvider.GetRequiredService<UserPortalDbContext>();
        var seeder = scope.ServiceProvider.GetRequiredService<DataSeeder>();

        ctx.Database.Migrate();

        seeder.SeedData();

        return app;
    }
}
