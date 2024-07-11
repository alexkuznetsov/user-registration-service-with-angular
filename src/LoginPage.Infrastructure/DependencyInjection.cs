using LoginPage.Application.Common.Authentication;
using LoginPage.Application.Common.Persistance;
using LoginPage.Application.Common.Services;
using LoginPage.Domain.Users;
using LoginPage.Infrastructure.Authentication;
using LoginPage.Infrastructure.Persistence;
using LoginPage.Infrastructure.Persistence.Repositories;
using LoginPage.Infrastructure.Services;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LoginPage.Infrastructure;

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
        services.AddDbContext<LoginPageDbContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("DefaultEntities")));

        services.AddScoped<ICountriesRepository, CountriesRepository>();
        services.AddScoped<IProvincesRepository, ProvincesRepository>();
        services.AddScoped<IUserLocationsRepository, UserLocationsRepository>();
        services.AddScoped<IUsersRepository, UsersRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();


        services.AddScoped<DataSeeder>();

        return services;
    }

    public static WebApplication UseDatabaseMigrator(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var ctx = scope.ServiceProvider.GetRequiredService<LoginPageDbContext>();
        var seeder = scope.ServiceProvider.GetRequiredService<DataSeeder>();

        ctx.Database.Migrate();

        seeder.SeedData();

        return app;
    }
}
