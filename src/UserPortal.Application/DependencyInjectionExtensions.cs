using FluentValidation;
using FluentValidation.AspNetCore;

using MediatR;

using Microsoft.Extensions.DependencyInjection;

using UserPortal.Application.Common.PipelineBehaviurs;

namespace UserPortal.Application;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationMediatorPipelineBehavior<,>));

        services.AddMediatR(c =>
        {
            c.RegisterServicesFromAssembly(typeof(DependencyInjectionExtensions).Assembly);
        });


        //register fluent validation
        services.AddFluentValidationAutoValidation()
            .AddValidatorsFromAssembly(typeof(DependencyInjectionExtensions).Assembly);

        services.AddTransient<Dispatcher>();

        return services;
    }
}