namespace Domain.UserAggregate;
public sealed class User : AggregateRoot<UserId>, IAuditableEntity
{
    private User() { }
    private User(
        FirstName firstName,
        LastName lastName,
        Email email,
        string? password,
        UserId? userId = null) : base(userId ?? new UserId(Guid.NewGuid()))
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
    }

    public FirstName? FirstName { get; private set; }
    public LastName? LastName { get; private set; }
    public Email? Email { get; private set; }
    public string? Password { get; private set; }
    public bool IsDeleted { get; private set; } = false;
    public DateTime? DeletedAtUtc { get; set; }
    public DateTime CreatedOnUtc { get; set; }
    public DateTime? ModifiedOnUtc { get; set; }
    public ICollection<Role>? Roles { get; set; }

    public static User Create(
        FirstName firstName,
        LastName lastName,
        Email email,
        string password)
    {
        var user = new User(
            firstName,
            lastName,
            email,
            password);

        return user;
    }

    public void DeleteUser()
    {
        IsDeleted = true;
    }
}
