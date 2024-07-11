using UserPortal.Domain.Common;

namespace UserPortal.Domain.Locations;

public class Country : AggregateRoot<CountryId, Guid>
{
    public DateTime CreatedAt { get; private set; }
    public string Name { get; private set; }

    private Country(CountryId id, DateTime createdAt, string name) :
        base(id)
    {
        CreatedAt = createdAt;
        Name = name;
    }

    private Country()
    {

    }

    public static Country Create(string name)
    {
        return new(CountryId.CreateUnique(), DateTime.UtcNow, name);
    }
}

