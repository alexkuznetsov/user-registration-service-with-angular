using UserPortal.Domain.Users;

namespace UserPortal.Application.Common.Persistance;
public interface IUsersRepository
{
    Task<User?> FindByEmail(string email, CancellationToken cancellationToken = default);

    void Add(User user);
    IQueryable<User> GetAll();
}
