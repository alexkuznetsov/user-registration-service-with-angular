using UserPortal.Domain.Common;

namespace UserPortal.Domain.Locations;

public class Province : Entity<ProvinceId>
{
    public DateTime CreatedAt { get; private set; }
    public Country Country { get; private set; }
    public string Name { get; private set; }

    private Province(ProvinceId id, DateTime createdAt, Country country, string name)
        : base(id)
    {
        CreatedAt = createdAt;
        Country = country;
        Name = name;
    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private Province() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public static Province Create(ProvinceId id, string name, Country country)
        => new(id, DateTime.UtcNow, country, name);
    public static Province Create(string name, Country country)
            => new(ProvinceId.CreateUnique(), DateTime.UtcNow, country, name);
}