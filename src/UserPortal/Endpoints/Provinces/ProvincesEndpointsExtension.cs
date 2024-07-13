using Asp.Versioning;
using Asp.Versioning.Builder;

using UserPortal.Application;
using UserPortal.Application.Provinces.Queries;

namespace UserPortal.Endpoints.Weather;

internal static class ProvincesEndpointsExtension
{
    internal static WebApplication UseProvincesEndpoints(this WebApplication app)
    {
        ApiVersionSet apiVersionSet = app.NewApiVersionSet()
           .HasApiVersion(new ApiVersion(1))
           .ReportApiVersions()
       .Build();

        app.MapGet("/api/v{version:apiVersion}/provinces/{countryId}", GetProvincesByCountryIdAsync)
            .AllowAnonymous()
            .WithName("GetProvinciesData")
            .WithApiVersionSet(apiVersionSet)
            .MapToApiVersion(1)
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
