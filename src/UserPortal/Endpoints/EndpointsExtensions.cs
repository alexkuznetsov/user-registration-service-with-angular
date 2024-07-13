using UserPortal.Endpoints.Weather;

namespace UserPortal.Endpoints;

internal static class EndpointsExtensions
{
    internal static WebApplication UseApplicationEndpoints(this WebApplication app)
    {
        app.UseWeatherEp()
           .UseCountriesEndpoints()
           .UseProvincesEndpoints()
           .UseSecurityEndpoints()
           .UseRegistrationEndpoints();

        return app;
    }
}
