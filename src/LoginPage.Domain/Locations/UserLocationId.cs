using LoginPage.Domain.Common;

namespace LoginPage.Domain.Locations;

public class UserLocationId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

    private UserLocationId(Guid value)
    {
        Value = value;
    }

    public static UserLocationId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static UserLocationId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
