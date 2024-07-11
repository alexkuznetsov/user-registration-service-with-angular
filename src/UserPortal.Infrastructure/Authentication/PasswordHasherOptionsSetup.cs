using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace UserPortal.Infrastructure.Authentication;

internal class PasswordHasherOptionsSetup : IConfigureOptions<PasswordHasherOptions>
{
    public void Configure(PasswordHasherOptions options)
    {
        options.IterationCount = 100000;
        options.CompatibilityMode = PasswordHasherCompatibilityMode.IdentityV3;
    }
}