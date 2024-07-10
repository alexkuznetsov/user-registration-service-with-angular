using LoginPage.Application.Common.Authentication;
using LoginPage.Application.Common.Services;
using LoginPage.Infrastructure.Authentication;
using LoginPage.Infrastructure.Persistence;
using LoginPage.Infrastructure.Services;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LoginPage.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddOptions();
        services.ConfigureOptions<JwtAuthenticationSettingsSetup>();
        services.AddSingleton<IClock, UtcClock>();
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer();

        services.ConfigureOptions<JwtBearerOptionsSetup>();

        services.AddPersistence();

        return services;
    }

    private static IServiceCollection AddPersistence(this IServiceCollection services)
    {

        services.AddDbContext<LoginPageDbContent>(options =>
            options.UseSqlite($"Data Source=loginpage.db"));

        return services;
    }
}
