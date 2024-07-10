using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace LoginPage.Infrastructure.Authentication;
internal class JwtAuthenticationSettingsSetup : IConfigureOptions<JwtAuthenticationSettings>
{
    static class Keys
    {
        internal static string OptionsSection = "JwtOptions";
    }

    private readonly IConfiguration _configuration;

    public JwtAuthenticationSettingsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(JwtAuthenticationSettings options)
    {
        _configuration.GetSection(Keys.OptionsSection).Bind(options);
    }
}
