using UserPortal.Domain.Users;

namespace UserPortal.Application.Common.Authentication;

public interface IJwtTokenGenerator
{
    (string, string) GenerateToken(User user);
}