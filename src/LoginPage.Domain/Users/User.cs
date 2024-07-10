using LoginPage.Domain.Common;

namespace LoginPage.Domain.Users;

public class User : AggregateRoot<UserId, Guid>
{
    public string UserName { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    private User(UserId id,
        string userName,
        string email,
        string password,
        DateTime createdAt,
        DateTime updatedAt)
        : base(id)
    {
        UserName = userName;
        Email = email;
        Password = password;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public static User Create(
        string userName,
        string email,
        string password)
    {
        return new(UserId.CreateUnique(), userName, email, password,
            DateTime.UtcNow, DateTime.UtcNow);
    }

#pragma warning disable CS8618
    private User() { }
#pragma warning restore CS8618
}
