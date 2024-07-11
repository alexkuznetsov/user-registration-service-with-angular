using LoginPage.Application.Common.Persistance;
using LoginPage.Domain.Locations;

namespace LoginPage.Infrastructure.Persistence.Repositories;

internal class UserLocationsRepository : IUserLocationsRepository
{
    private readonly LoginPageDbContext _context;

    public UserLocationsRepository(LoginPageDbContext context)
    {
        _context = context;
    }

    public void Add(UserLocation userLocation)
    {
        _context.UserLocations.Add(userLocation);
    }

    public IQueryable<UserLocation> GetAll()
    {
        return _context.UserLocations;
    }
}
