using LoginPage.Application.Common.Persistance;
using LoginPage.Domain.Users;

using Microsoft.EntityFrameworkCore;

namespace LoginPage.Infrastructure.Persistence.Repositories;
public class UsersRepository : IUsersRepository
{
    private readonly LoginPageDbContext _context;

    public UsersRepository(LoginPageDbContext context)
    {
        _context = context;
    }

    public Task<User?> FindByEmail(string email, CancellationToken cancellationToken = default)
    {
        return _context.Users.FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
    }
}
