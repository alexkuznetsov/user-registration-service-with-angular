using UserPortal.Application.Common.Services;

namespace UserPortal.Infrastructure.Services;
internal class UtcClock : IClock
{
    public DateTime UtcNow => DateTime.UtcNow;
}
