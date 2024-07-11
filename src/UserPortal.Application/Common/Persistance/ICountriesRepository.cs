using UserPortal.Domain.Locations;

namespace UserPortal.Application.Common.Persistance;


public interface ICountriesRepository
{
    void Add(Country country);
    IQueryable<Country> GetAll();
}
