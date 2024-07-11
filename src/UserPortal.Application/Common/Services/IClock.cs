namespace UserPortal.Application.Common.Services;
public interface IClock
{
    DateTime UtcNow { get; }
}
