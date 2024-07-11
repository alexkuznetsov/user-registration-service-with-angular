namespace UserPortal.Application.Common.Services;

public interface IUnitOfWorkTransaction : IDisposable
{
    Task CommitAsync(CancellationToken cancellationToken = default);
    Task RoolbackAsync(CancellationToken cancellationToken = default);
}
