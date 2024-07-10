using LoginPage.Domain.Common;
using LoginPage.Domain.Locations;
using LoginPage.Domain.Users;

namespace LoginPage.Domain.UserLocations;

public class UserLocation : AggregateRoot<UserLocationId, Guid>
{
    public DateTime CreatedAt { get; }
    public ProvinceId ProvinceId { get; }

    public UserId UserId { get; }

    private UserLocation(UserLocationId id, DateTime createdAt, UserId userId, ProvinceId provinceId) :
        base(id)
    {
        CreatedAt = createdAt;
        UserId = userId;
        ProvinceId = provinceId;
    }

    public static UserLocation Create(UserId userId, ProvinceId provinceId)
    {
        return new(UserLocationId.CreateUnique(), DateTime.UtcNow, userId, provinceId);
    }
}

