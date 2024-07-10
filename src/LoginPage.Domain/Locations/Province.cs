using LoginPage.Domain.Common;

namespace LoginPage.Domain.Locations;

public class Province : Entity<ProvinceId>
{
    public DateTime CreatedAt { get; }
    public CountryId CountryId { get; }
    public string Name { get; }


    private Province(ProvinceId id, DateTime createdAt, CountryId countryId, string name)
        : base(id)
    {
        CreatedAt = createdAt;
        CountryId = countryId;
        Name = name;
    }


    public static Province Create(string name, CountryId countryId)
            => new(ProvinceId.CreateUnique(), DateTime.UtcNow, countryId, name);
}