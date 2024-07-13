using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace UserPortal.Endpoints;

internal static class EndpointRouteBuilderExtensions
{

    public static readonly string[] DefaultPoliciesForApi = ["Bearer"];
    private static readonly DenyAnonymousAuthorizationRequirement DenyAnonymousAuthorizationRequirement = new();

    public static RouteHandlerBuilder WithSecurity(this RouteHandlerBuilder builder)
    {
        return builder.RequireAuthorization(configurePolicy =>
        {
            configurePolicy.AddAuthenticationSchemes(DefaultPoliciesForApi);
            configurePolicy.AddRequirements(DenyAnonymousAuthorizationRequirement);
        });
    }
}