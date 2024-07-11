using UserPortal.Application.Common.Persistance;
using UserPortal.Domain.Users;

using Microsoft.EntityFrameworkCore;

namespace UserPortal.Infrastructure.Persistence.Repositories;
public class UsersRepository : IUsersRepository
{
    private readonly UserPortalDbContext _context;

    public UsersRepository(UserPortalDbContext context)
    {
        _context = context;
    }

    public void Add(User user)
    {
        _context.Add(user);
    }

    public Task<User?> FindByEmail(string email, CancellationToken cancellationToken = default)
    {
        return GetAll().FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
    }

    public IQueryable<User> GetAll()
    {
        return _context.Users;
    }
}
