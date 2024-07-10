using LoginPage.Domain.Common;

namespace LoginPage.Domain.Locations;

public class Province : Entity<ProvinceId>
{
    public DateTime CreatedAt { get; }
    public Country Country { get; }
    public string Name { get; }


    private Province(ProvinceId id, DateTime createdAt, Country country, string name)
        : base(id)
    {
        CreatedAt = createdAt;
        Country = country;
        Name = name;
    }


    public static Province Create(string name, Country country)
            => new(ProvinceId.CreateUnique(), DateTime.UtcNow, country, name);
}