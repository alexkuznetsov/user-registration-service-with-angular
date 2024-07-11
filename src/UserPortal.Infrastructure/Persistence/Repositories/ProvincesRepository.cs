using UserPortal.Application.Common.Persistance;
using UserPortal.Domain.Locations;

using Microsoft.EntityFrameworkCore;

namespace UserPortal.Infrastructure.Persistence.Repositories;

internal class ProvincesRepository : IProvincesRepository
{
    private readonly UserPortalDbContext _context;

    public ProvincesRepository(UserPortalDbContext context)
    {
        _context = context;
    }

    public void Add(Province province)
    {
        _context.Provinces.Add(province);
    }

    public Task<Province?> FindAsync(ProvinceId id, CancellationToken cancellationToken = default)
    {
        return _context.Provinces.Where(p => p.Id == id)
            .SingleOrDefaultAsync(cancellationToken);
    }

    public IQueryable<Province> GetAll()
    {
        return _context.Provinces
            .Include(x => x.Country);
    }

    public IQueryable<Province> GetAllByCountry(CountryId countryId)
    {
        return _context.Provinces
           .Include(x => x.Country)
           .Where(x => x.Country.Id == countryId);
    }
}
