namespace UserPortal.Application.Common.Services;
public interface IUnitOfWork
{
    Task<IUnitOfWorkTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);

    void Save();
    Task SaveAsync(CancellationToken cancellationToken = default);
}
