namespace Modules.Users.Domain.Users;

/// <summary>
/// Represents the user entity.
/// </summary>
public sealed class User : Entity<UserId>, IAuditable
{
    private readonly HashSet<Role> _roles = [];

    /// <summary>
    /// Initializes a new instance of the <see cref="User"/> class.
    /// </summary>
    /// <param name="id">The Id.</param>
    /// <param name="identityProviderId">The identity provider id.</param>
    /// <param name="email">The email.</param>
    /// <param name="firstName">The first name.</param>
    /// <param name="lastName">The last name.</param>
    private User(UserId id, string identityProviderId, string email, string firstName, string lastName)
        : base(id)
    {
        IdentityProviderId = identityProviderId;
        Email = email;
        FirstName = firstName;
        LastName = lastName;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="User"/> class.
    /// </summary>
    /// <remarks>
    /// Used for EF Core.
    /// </remarks>
    private User()
    {
    }

    /// <summary>
    /// Gets the identity provider id.
    /// </summary>
    public string IdentityProviderId { get; private set; } = null!;

    /// <summary>
    /// Gets the email.
    /// </summary>
    public string Email { get; private set; } = null!;

    /// <summary>
    /// Gets the first name.
    /// </summary>
    public string FirstName { get; private set; } = null!;

    /// <summary>
    /// Gets the last name.
    /// </summary>
    public string LastName { get; private set; } = null!;

    /// <summary>
    /// Gets the roles.
    /// </summary>
    public IReadOnlyCollection<Role> Roles => _roles.ToList().AsReadOnly();

    /// <inheritdoc/>
    public DateTime CreatedOnUtc { get; }

    /// <inheritdoc/>
    public DateTime? ModifiedOnUtc { get; }

    /// <summary>
    /// Creates a new user with the specified parameters.
    /// </summary>
    /// <param name="id">The id.</param>
    /// <param name="identityProviderId">The identity provider id.</param>
    /// <param name="email">The email.</param>
    /// <param name="firstName">The first name.</param>
    /// <param name="lastName">The last name.</param>
    /// <returns>The new user instance.</returns>
    public static ErrorOr<User> Create(
        UserId id,
        string identityProviderId,
        string email,
        string firstName,
        string lastName)
    {
        var user = new User(id, identityProviderId, email, firstName, lastName);

        user._roles.Add(Role.Registered);

        user.RaiseDomainEvent(new UserRegisteredDomainEvent(
            DefaultIdType.NewGuid(),
            SystemTimeProvider.UtcNow(),
            user.Id,
            null,
            user.Email,
            user.FirstName,
            user.LastName,
            user._roles.Select(role => role.Name).ToHashSet()));

        return user;
    }

    /// <summary>
    /// Creates a new user based on the specified registration.
    /// </summary>
    /// <param name="userRegistration">The user registration.</param>
    /// <returns>The new user instance.</returns>
    public static ErrorOr<User> CreateFromRegistration(UserRegistration userRegistration)
    {
        if (userRegistration is null)
        {
            ArgumentNullException.ThrowIfNull(userRegistration);
        }

        if (userRegistration.Status != UserRegistrationStatus.Confirmed)
        {
            return UserErrors.RegistrationIsNotConfirmed;
        }

        if (string.IsNullOrWhiteSpace(userRegistration.IdentityProviderId) ||
            string.IsNullOrWhiteSpace(userRegistration.FirstName) ||
            string.IsNullOrWhiteSpace(userRegistration.LastName))
        {
            return UserErrors.RegistrationIsIncomplete;
        }

        var user = new User(
            new UserId(DefaultIdType.NewGuid()),
            userRegistration.IdentityProviderId,
            userRegistration.Email,
            userRegistration.FirstName,
            userRegistration.LastName);

        user._roles.Add(Role.Registered);

        user.RaiseDomainEvent(new UserRegisteredDomainEvent(
            DefaultIdType.NewGuid(),
            SystemTimeProvider.UtcNow(),
            user.Id,
            userRegistration.Id,
            user.Email,
            user.FirstName,
            user.LastName,
            user._roles.Select(role => role.Name).ToHashSet()));

        return user;
    }

    /// <summary>
    /// Changes the user's basic information.
    /// </summary>
    /// <param name="firstName">The first name.</param>
    /// <param name="lastName">The last name.</param>
    public void Change(string firstName, string lastName)
    {
        bool basicInformationChanged = FirstName != firstName || LastName != lastName;

        FirstName = firstName;
        LastName = lastName;

        if (basicInformationChanged)
        {
            RaiseDomainEvent(new UserChangedDomainEvent(
                DefaultIdType.NewGuid(),
                SystemTimeProvider.UtcNow(),
                Id,
                FirstName,
                LastName,
                _roles.Select(role => role.Name).ToHashSet()));
        }
    }
}
