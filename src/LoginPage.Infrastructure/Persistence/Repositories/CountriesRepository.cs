using LoginPage.Application.Common.Persistance;
using LoginPage.Domain.Locations;

namespace LoginPage.Infrastructure.Persistence.Repositories;

internal class CountriesRepository : ICountriesRepository
{
    private readonly LoginPageDbContext _context;

    public CountriesRepository(LoginPageDbContext context)
    {
        _context = context;
    }

    public IQueryable<Country> GetAll()
    {
        return _context.Countries;
    }
}
