using UserPortal.Domain.Locations;

namespace UserPortal.Application.Common.Persistance;

public interface IProvincesRepository
{
    IQueryable<Province> GetAll();
    IQueryable<Province> GetAllByCountry(CountryId countryId);

    Task<Province?> FindAsync(ProvinceId id, CancellationToken cancellationToken = default);
    void Add(Province provinceKz1);
}
