using UserPortal.Application.Common.Services;
using UserPortal.Infrastructure.Persistence;

namespace UserPortal.Infrastructure.Services;

internal class UnitOfWork : IUnitOfWork
{
    private readonly UserPortalDbContext _context;

    public UnitOfWork(UserPortalDbContext context)
    {
        _context = context;
    }

    public async Task<IUnitOfWorkTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        var tx = await _context.Database.BeginTransactionAsync(cancellationToken);
        return new DefaultUnitOfWorkTransaction(tx);
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    public Task SaveAsync(CancellationToken cancellationToken = default)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }
}
