using UserPortal.Domain.Common;

namespace UserPortal.Domain.Locations;

public class ProvinceId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

    private ProvinceId(Guid value)
    {
        Value = value;
    }

    public static ProvinceId CreateUnique()
        => new(Guid.NewGuid());

    public static ProvinceId Create(string value)
        => Create(Guid.Parse(value));

    public static ProvinceId Create(Guid value)
        => new(value);

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
