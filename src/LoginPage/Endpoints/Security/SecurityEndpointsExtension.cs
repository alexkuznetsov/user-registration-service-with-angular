using LoginPage.Application;
using LoginPage.Application.Common.Authentication;
using LoginPage.Application.Users.Queries;
using LoginPage.Domain.Users;

using Microsoft.AspNetCore.Identity;

namespace LoginPage.Endpoints.Weather;

internal static class SecurityEndpointsExtension
{
    internal static WebApplication UseSecurityEndpoints(this WebApplication app)
    {
        app.MapPost("/api/user/token", GetUserTokenAsync)
            .AllowAnonymous()
            .WithName("GetUserToken")
            .WithOpenApi();


        return app;
    }


    private static async Task<IResult> GetUserTokenAsync(UserLoginRequest userLoginRequest,
        Dispatcher dispatcher,
        IPasswordHasher<User> passwordHasher,
        IJwtTokenGenerator jwtTokenGenerator,
        CancellationToken cancellationToken)
    {
        var result = await dispatcher.SendAsync(new GetUserByEmail.Query(userLoginRequest.Email), cancellationToken);

        if (result.IsNotFound())
        {
            return Results.NotFound(new
            {
                Success = false,
                Message = "User not found"
            });
        }

        var verifyResult = passwordHasher.VerifyHashedPassword(result.Result, result.Result.Password, userLoginRequest.Password);

        if (verifyResult != PasswordVerificationResult.Success)
        {
            return Results.BadRequest(new
            {
                Success = false,
                Message = "Email or password are incorrect"
            });
        }

        var jwt = jwtTokenGenerator.GenerateToken(result.Result);

        return Results.Ok(new
        {
            Success = true,
            TokenData = new
            {
                AccessToken = jwt.Item1,
                ResfresToken = jwt.Item2,
            }
        });
    }


    internal class UserLoginRequest
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
