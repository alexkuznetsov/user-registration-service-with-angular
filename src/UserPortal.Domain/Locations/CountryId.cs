using UserPortal.Domain.Common;

namespace UserPortal.Domain.Locations;

public class CountryId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

    private CountryId(Guid value)
    {
        Value = value;
    }

    public static CountryId CreateUnique()
        => new(Guid.NewGuid());

    public static CountryId Create(string value)
        => new(Guid.Parse(value));

    public static CountryId Create(Guid value)
        => new(value);

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
