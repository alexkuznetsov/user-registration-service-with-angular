using LoginPage.Application.Common.Persistance;
using LoginPage.Infrastructure.Persistence;

namespace LoginPage.Infrastructure.Services;

internal class UnitOfWork : IUnitOfWork
{
    private readonly LoginPageDbContext _context;

    public UnitOfWork(LoginPageDbContext context)
    {
        _context = context;
    }

    public void Commit()
    {
        _context.SaveChanges();
    }

    public Task CommitAsync(CancellationToken cancellationToken = default)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }
}