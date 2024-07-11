using LoginPage.Domain.Common;
using LoginPage.Domain.Users;

namespace LoginPage.Domain.Locations;

public class UserLocation : AggregateRoot<UserLocationId, Guid>
{
    public DateTime CreatedAt { get; private set; }
    public Province Province { get; private set; }

    public User User { get; }

    private UserLocation(UserLocationId id, DateTime createdAt, User user, Province province) :
        base(id)
    {
        CreatedAt = createdAt;
        User = user;
        Province = province;
    }

    private UserLocation()
    { }

    public static UserLocation Create(User user, Province province)
    {
        return new(UserLocationId.CreateUnique(), DateTime.UtcNow, user, province);
    }
}

