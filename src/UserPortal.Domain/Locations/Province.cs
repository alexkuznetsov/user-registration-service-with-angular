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

    private Province()
    {

    }


    public static Province Create(string name, Country country)
            => new(ProvinceId.CreateUnique(), DateTime.UtcNow, country, name);
}