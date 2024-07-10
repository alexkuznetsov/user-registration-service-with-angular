using LoginPage.Domain.Common;

namespace LoginPage.Domain.Locations;

public class Country : AggregateRoot<CountryId, Guid>
{
    private readonly List<Province> _provincies = [];

    public DateTime CreatedAt { get; }
    public string Name { get; }

    public IReadOnlyList<Province> Provinces => _provincies.AsReadOnly();

    private Country(CountryId id, DateTime createdAt, string name, List<Province>? provincies) :
        base(id)
    {
        CreatedAt = createdAt;
        Name = name;
        _provincies = provincies ?? [];
    }

    public Province AddProvince(string name)
    {
        var province = Province.Create(name, (CountryId)Id);

        _provincies.Add(province);

        return province;
    }

    public static Country Create(string name)
    {
        return new(CountryId.CreateUnique(), DateTime.UtcNow, name, []);
    }
}

