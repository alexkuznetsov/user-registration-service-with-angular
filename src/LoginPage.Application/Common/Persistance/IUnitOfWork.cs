namespace LoginPage.Application.Common.Persistance;
public interface IUnitOfWork
{
    void Commit();
    Task CommitAsync(CancellationToken cancellationToken = default);
}
