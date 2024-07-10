using LoginPage.Domain.Users;

namespace LoginPage.Application.Common.Authentication;

public interface IJwtTokenGenerator
{
    (string, string) GenerateToken(User user);
}