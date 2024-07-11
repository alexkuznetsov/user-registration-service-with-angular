using UserPortal.Domain.Common;
using UserPortal.Domain.Locations;

namespace UserPortal.Domain.Users;

public class User : AggregateRoot<UserId, Guid>
{
    public string Email { get; private set; }
    public string Password { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public Province Province { get; private set; }

    private User(UserId id,
        string email,
        string password,
        DateTime createdAt,
        Province province)
        : base(id)
    {
        Email = email;
        Password = password;
        CreatedAt = createdAt;
        Province = province;
    }

    public static User Create(string email,
        string password, Province province)
    {
        return new(UserId.CreateUnique(), email, password,
            DateTime.UtcNow, province);
    }

    public void SetPassword(string hashedPassword)
        => Password = hashedPassword;

#pragma warning disable CS8618
    private User() { }
#pragma warning restore CS8618
}
