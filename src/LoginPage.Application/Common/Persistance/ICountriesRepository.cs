using LoginPage.Domain.Locations;

namespace LoginPage.Application.Common.Persistance;


public interface ICountriesRepository
{
    IQueryable<Country> GetAll();
}
