using LoginPage.Application;
using LoginPage.Application.Provinces.Queries;

namespace LoginPage.Endpoints.Weather;

internal static class ProvincesEndpointsExtension
{
    internal static WebApplication UseProvincesEndpoints(this WebApplication app)
    {
        app.MapGet("/api/provinces/{countryId}", GetProvincesByCountryIdAsync)
        .WithName("GetProvinciesData")
        .WithOpenApi();


        return app;
    }


    private static async Task<IResult> GetProvincesByCountryIdAsync(Dispatcher dispatcher, Guid countryId, CancellationToken cancellationToken)
    {
        var data = await dispatcher.SendAsync(new GetProviceList.Query(countryId));

        return Results.Ok(new
        {
            Success = true,
            Records = data.Result
        });
    }
}
