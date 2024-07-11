using LoginPage.Domain.Locations;

namespace LoginPage.Application.Common.Persistance;

public interface IProvincesRepository
{
    IQueryable<Province> GetAll();
    IQueryable<Province> GetAllByCountry(CountryId countryId);
}
