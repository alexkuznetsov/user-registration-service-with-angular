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
    {
        return new(Guid.NewGuid());
    }

    public static ProvinceId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
