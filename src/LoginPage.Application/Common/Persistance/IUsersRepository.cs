using LoginPage.Domain.Users;

namespace LoginPage.Application.Common.Persistance;
public interface IUsersRepository
{
    Task<User?> FindByEmail(string email, CancellationToken cancellationToken = default);

    void Add(User user);
}
