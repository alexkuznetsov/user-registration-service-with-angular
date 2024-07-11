using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using LoginPage.Application.Common.Authentication;
using LoginPage.Application.Common.Services;
using LoginPage.Domain.Users;

using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace LoginPage.Infrastructure.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly JwtAuthenticationSettings _jwtOptions;
    private readonly IClock _clock;

    public JwtTokenGenerator(IClock clock, IOptions<JwtAuthenticationSettings> options)
    {
        _jwtOptions = options.Value;
        _clock = clock;
    }

    public (string, string) GenerateToken(User user)
    {
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.IssuerSigningKey));
        var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

        var tokenOptions1 = new JwtSecurityToken(
            issuer: _jwtOptions.ValidIssuer,
            audience: _jwtOptions.ValidAudience,
            claims: [
                        new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()!),
                        new Claim(JwtRegisteredClaimNames.Email, user.Email),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            ],
            notBefore: _clock.UtcNow,
            expires: _clock.UtcNow.AddMinutes(_jwtOptions.TimeToLive),
            signingCredentials: signinCredentials
        );

        var tokenOptions2 = new JwtSecurityToken(
           issuer: _jwtOptions.ValidIssuer,
            audience: _jwtOptions.ValidAudience,
           claims: [
                       new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()!),
                        new Claim(JwtRegisteredClaimNames.Email, user.Email),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
           ],
           notBefore: DateTime.UtcNow,
           expires: tokenOptions1.ValidTo.AddMinutes(10),
           signingCredentials: signinCredentials
       );

        var authTokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions1);
        var refreshTokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions2);

        return (authTokenString, refreshTokenString);
    }
}