using UserPortal.Application.Common.Persistance;
using UserPortal.Domain.Locations;

namespace UserPortal.Infrastructure.Persistence.Repositories;

internal class CountriesRepository : ICountriesRepository
{
    private readonly UserPortalDbContext _context;

    public CountriesRepository(UserPortalDbContext context)
    {
        _context = context;
    }

    public void Add(Country country)
    {
        _context.Add(country);
    }

    public IQueryable<Country> GetAll()
    {
        return _context.Countries;
    }
}
