using LoginPage.Endpoints.Weather;

namespace LoginPage.Endpoints;

internal static class EndpointsExtensions
{
    internal static WebApplication UseApplicationEndpoints(this WebApplication app)
    {
        app.UseWeatherEp();

        return app;
    }
}