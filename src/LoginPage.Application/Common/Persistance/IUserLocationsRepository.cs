using LoginPage.Domain.Locations;

namespace LoginPage.Application.Common.Persistance;

public interface IUserLocationsRepository
{
    IQueryable<UserLocation> GetAll();
    void Add(UserLocation userLocation);
}