using UserPortal.Application;
using UserPortal.Application.Countries.Queries;

namespace UserPortal.Endpoints.Weather;

internal static class CountriesEndpointsExtension
{
    internal static WebApplication UseCountriesEndpoints(this WebApplication app)
    {
        app.MapGet("/api/countries", GetCountriesDataAsync)
            .WithSecurity()
            .WithName("GetCountriesData")
            .WithOpenApi();


        return app;
    }


    static async Task<IResult> GetCountriesDataAsync(Dispatcher dispatcher, CancellationToken cancellationToken)
    {
        var countries = await dispatcher.SendAsync(new CountriesList.Query(), cancellationToken);

        return Results.Ok(new
        {
            Success = true,
            Records = countries.Result,
        });
    }
}
