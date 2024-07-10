using LoginPage.Domain.Common;

namespace LoginPage.Domain.Locations;

public class CountryId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

    private CountryId(Guid value)
    {
        Value = value;
    }

    public static CountryId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static CountryId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
