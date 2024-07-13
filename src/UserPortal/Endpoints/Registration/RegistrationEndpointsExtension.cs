using System.ComponentModel.DataAnnotations;

using Asp.Versioning;
using Asp.Versioning.Builder;

using Microsoft.AspNetCore.Identity;

using UserPortal.Application;
using UserPortal.Application.Common.Authentication;
using UserPortal.Application.Provinces.Queries;
using UserPortal.Application.Users.Commands;
using UserPortal.Application.Users.Queries;
using UserPortal.Domain.Users;

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


    private static async Task<IResult> CreateUserAsync(UserRegisterRequest userLoginRequest,
        Dispatcher dispatcher,
        IPasswordHasher<User> passwordHasher,
        IJwtTokenGenerator jwtTokenGenerator,
        CancellationToken cancellationToken)
    {
        var result = await dispatcher.SendAsync(new UserByEmail.Query(userLoginRequest.Login),
            cancellationToken);

        if (!result.IsNotFound())
        {
            return Results.BadRequest(new
            {
                Success = false,
                Message = "User already exists"
            });
        }

        var province = await dispatcher.SendAsync(
            new ProvinceFindOne.Query(userLoginRequest.ProvinceId.GetValueOrDefault()), cancellationToken);

        if (province.IsNotFound())
        {
            return Results.BadRequest(new
            {
                Success = false,
                Message = "Province not found"
            });
        }

        var user = User.Create(userLoginRequest.Login, "", province.Result);
        var passwordHash = passwordHasher.HashPassword(user, userLoginRequest.Password);

        user.SetPassword(passwordHash);

        var registerResult = await dispatcher.SendAsync(new UserSave.Command(user), cancellationToken);


        return registerResult.IsOk()
            ? Results.Ok(new { Success = true })
            : Results.BadRequest(new { Success = false, Message = "User not registered" });
    }


    internal class UserRegisterRequest
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "EmailMustBeFilled", ErrorMessageResourceType = typeof(RegisterValidationMessages))]
        [EmailAddress(ErrorMessage = "EmailMustBeValid", ErrorMessageResourceType = typeof(RegisterValidationMessages))]
        public string Login { get; set; } = null!;

        [Required(AllowEmptyStrings = false, ErrorMessage = "PasswordMustBeFilled", ErrorMessageResourceType = typeof(RegisterValidationMessages))]
        [Compare(nameof(Password2), ErrorMessage = "PasswordsMushBeEquals", ErrorMessageResourceType = typeof(RegisterValidationMessages))]
        public string Password { get; set; } = null!;

        [Required(AllowEmptyStrings = false, ErrorMessage = "PasswordMustBeFilled", ErrorMessageResourceType = typeof(RegisterValidationMessages))]
        public string Password2 { get; set; } = null!;

        public bool? AgreeToWork { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "ProvinceMustBeFilled", ErrorMessageResourceType = typeof(RegisterValidationMessages))]
        public Guid? ProvinceId { get; set; }
    }
}
