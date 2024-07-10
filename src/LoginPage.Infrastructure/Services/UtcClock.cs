using LoginPage.Application.Common.Services;

namespace LoginPage.Infrastructure.Services;
internal class UtcClock : IClock
{
    public DateTime UtcNow => DateTime.UtcNow;
}
