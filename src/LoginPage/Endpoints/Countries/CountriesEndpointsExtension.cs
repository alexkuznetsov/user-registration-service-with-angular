using LoginPage.Application;
using LoginPage.Application.Countries.Queries;

namespace LoginPage.Endpoints.Weather;

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
        var countries = await dispatcher.SendAsync(new GetCountriesList.Query(), cancellationToken);

        return Results.Ok(new
        {
            Success = true,
            Records = countries.Result,
        });
    }
}
