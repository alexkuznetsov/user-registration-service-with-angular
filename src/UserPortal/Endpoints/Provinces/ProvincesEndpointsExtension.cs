using UserPortal.Application;
using UserPortal.Application.Provinces.Queries;

namespace UserPortal.Endpoints.Weather;

internal static class ProvincesEndpointsExtension
{
    internal static WebApplication UseProvincesEndpoints(this WebApplication app)
    {
        app.MapGet("/api/provinces/{countryId}", GetProvincesByCountryIdAsync)
            .WithSecurity()
            .WithName("GetProvinciesData")
            .WithOpenApi();


        return app;
    }


    private static async Task<IResult> GetProvincesByCountryIdAsync(Dispatcher dispatcher, Guid countryId, CancellationToken cancellationToken)
    {
        var data = await dispatcher.SendAsync(new ProvicesList.Query(countryId));

        return Results.Ok(new
        {
            Success = true,
            Records = data.Result
        });
    }
}
