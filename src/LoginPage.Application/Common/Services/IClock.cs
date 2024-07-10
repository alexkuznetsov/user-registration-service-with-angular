namespace LoginPage.Application.Common.Services;
public interface IClock
{
    DateTime UtcNow { get; }
}
