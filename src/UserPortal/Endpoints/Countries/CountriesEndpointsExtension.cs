using Asp.Versioning;
using Asp.Versioning.Builder;

using UserPortal.Application;
using UserPortal.Application.Countries.Queries;

namespace UserPortal.Endpoints.Weather;

internal static class CountriesEndpointsExtension
{
    internal static WebApplication UseCountriesEndpoints(this WebApplication app)
    {

        ApiVersionSet apiVersionSet = app.NewApiVersionSet()
            .HasApiVersion(new ApiVersion(1))
            .ReportApiVersions()
        .Build();

        app.MapGet("/api/v{version:apiVersion}/countries", GetCountriesDataAsync)
            .AllowAnonymous()
            .WithName("GetCountriesData")
            .WithApiVersionSet(apiVersionSet)
            .MapToApiVersion(1)
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
