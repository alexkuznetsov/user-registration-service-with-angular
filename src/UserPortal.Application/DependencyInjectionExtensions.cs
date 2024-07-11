using Microsoft.Extensions.DependencyInjection;

namespace UserPortal.Application;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(c =>
        {
            c.RegisterServicesFromAssembly(typeof(DependencyInjectionExtensions).Assembly);
        });

        services.AddTransient<Dispatcher>();

        return services;
    }
}