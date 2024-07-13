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

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private Country() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public static Country Create(CountryId id, string name)
        => new(id, DateTime.UtcNow, name);

    public static Country Create(string name)
        => new(CountryId.CreateUnique(), DateTime.UtcNow, name);
}

