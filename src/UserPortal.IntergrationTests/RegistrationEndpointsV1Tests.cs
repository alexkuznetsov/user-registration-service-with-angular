using System.Net;

using UserPortal.Infrastructure.Persistence;
using UserPortal.IntergrationTests.Configuration;
using UserPortal.IntergrationTests.Data;
using UserPortal.IntergrationTests.FailureModels;

using Xunit;

namespace UserPortal.IntergrationTests;


public class RegistrationEndpointsV1Tests : IClassFixture<UpTestWebApplicationFactory<Program>>
{
    private readonly UpTestWebApplicationFactory<Program> _factory;
    private readonly HttpClient _httpClient;

    public RegistrationEndpointsV1Tests(UpTestWebApplicationFactory<Program> factory)
    {
        _factory = factory;
        _httpClient = factory.CreateClient();
    }

    public static IEnumerable<object[]> InvalidRegistrationRequests => Models.InvalidRegistrationRequests;


    [Theory]
    [MemberData(nameof(InvalidRegistrationRequests))]
    public async Task PostRegistrationWithValidationProblems(UserRegisterRequest todo, string errorMessage)
    {
        var response = await _httpClient.PostAsJsonAsync("/api/v1/register", todo);

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

        var raw = await response.Content.ReadAsStringAsync();

        var problemResult = await response.Content.ReadFromJsonAsync<TypedRegistrationProblemDetail>();

        Assert.NotNull(problemResult?.Failures);
        Assert.Collection(problemResult.Failures, (error) => Assert.Equal(errorMessage, error.ErrorMessage));
    }

    [Fact]
    public async Task PostRegistrationWithValidParameters()
    {
        using (var scope = _factory.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetService<UserPortalDbContext>();
            if (db != null && db.Users.Any())
            {
                db.Users.RemoveRange(db.Users);
                await db.SaveChangesAsync();
            }
        }
        var response = await _httpClient.PostAsJsonAsync("/api/v1/register", new UserRegisterRequest
        {
            AgreeToWork = true,
            Login = "qwe@qwer",
            Password = "123q",
            Password2 = "123q",
            ProvinceId = Provinces.KZ_EastKazakhstan
        });

        var raw = await response.Content.ReadAsStringAsync();

        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }
}

