using UserPortal.Application.Common.Services;

using Microsoft.EntityFrameworkCore.Storage;

namespace UserPortal.Infrastructure.Services;

internal class DefaultUnitOfWorkTransaction : IUnitOfWorkTransaction
{
    private readonly IDbContextTransaction _efTransaction;
    private bool _disposed;

    internal DefaultUnitOfWorkTransaction(IDbContextTransaction efTransaction)
    {
        _efTransaction = efTransaction;
    }
    public Task CommitAsync(CancellationToken cancellationToken = default)
    {
        return _efTransaction.CommitAsync(cancellationToken);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (!_disposed)
            {
                _efTransaction.Dispose();
                _disposed = true;
            }
        }
    }

    public Task RoolbackAsync(CancellationToken cancellationToken = default)
    {
        return _efTransaction.RollbackAsync(cancellationToken);
    }
}