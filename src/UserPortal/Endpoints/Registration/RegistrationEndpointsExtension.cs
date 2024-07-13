using Asp.Versioning;
using Asp.Versioning.Builder;

using UserPortal.Application;
using UserPortal.Application.Users.Commands;

namespace UserPortal.Endpoints.Weather;

internal static class RegistrationEndpointsExtension
{
    internal static WebApplication UseRegistrationEndpoints(this WebApplication app)
    {
        ApiVersionSet apiVersionSet = app.NewApiVersionSet()
          .HasApiVersion(new ApiVersion(1))
          .ReportApiVersions()
        .Build();

        app.MapPost("/api/v{version:apiVersion}/register", CreateUserAsync)
            .AllowAnonymous()
            .WithName("CreateUserAsync")
            .WithApiVersionSet(apiVersionSet)
            .MapToApiVersion(1)
            .WithOpenApi();


        return app;
    }

    private static async Task<IResult> CreateUserAsync(UserRegisterRequest registrationRequest,
        Dispatcher dispatcher, CancellationToken cancellationToken)
    {
        var registerResult = await dispatcher.SendAsync(new UserSave.Command(Login: registrationRequest.Login,
            Password: registrationRequest.Password,
            Password2: registrationRequest.Password2,
            AgreeToWork: registrationRequest.AgreeToWork,
            ProvinceId: registrationRequest.ProvinceId), cancellationToken);

        return registerResult.IsOk()
            ? TypedResults.Created("", OperationResult.SuccessResult)
            : TypedResults.BadRequest(new OperationResult(false, "Failure", [.. registerResult.Failures]));
    }



    internal class UserRegisterRequest
    {
        public string Login { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string Password2 { get; set; } = null!;

        public bool? AgreeToWork { get; set; }

        public Guid? ProvinceId { get; set; }
    }

}
