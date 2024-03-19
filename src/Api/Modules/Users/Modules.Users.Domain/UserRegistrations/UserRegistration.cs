using Modules.Users.Domain.UserRegistrations.Events;

namespace Modules.Users.Domain.UserRegistrations;

/// <summary>
/// Represents a user registration.
/// </summary>
public sealed class UserRegistration : Entity<UserRegistrationId>, IAuditable
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UserRegistration"/> class.
    /// </summary>
    /// <param name="id">The id.</param>
    /// <param name="email">The email.</param>
    /// <param name="status">The status.</param>
    private UserRegistration(
        UserRegistrationId id,
        string email,
        UserRegistrationStatus status)
        : base(id)
    {
        Email = email;
        Status = status;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="UserRegistration"/> class.
    /// </summary>
    private UserRegistration()
    {
    }

    /// <summary>
    /// Gets the email.
    /// </summary>
    public string Email { get; private set; } = null!;

    /// <summary>
    /// Gets the identity provider identifier.
    /// </summary>
    public string? IdentityProviderId { get; private set; }

    /// <summary>
    /// Gets the first name.
    /// </summary>
    public string? FirstName { get; private set; } = null!;

    /// <summary>
    /// Gets the last name.
    /// </summary>
    public string? LastName { get; private set; } = null!;

    /// <summary>
    /// Gets the status.
    /// </summary>
    public UserRegistrationStatus Status { get; private set; } = null!;

    /// <summary>
    /// Gets the confirmed on date and time.
    /// </summary>
    public DateTime? ConfirmedOnUtc { get; private set; }

    /// <inheritdoc/>
    public DateTime CreatedOnUtc { get; }

    /// <inheritdoc/>
    public DateTime? ModifiedOnUtc { get; }

    /// <summary>
    /// Creates a new user registration with the specified id and email.
    /// </summary>
    /// <param name="id">The id.</param>
    /// <param name="email">The email.</param>
    /// <returns>The new user registration instance.</returns>
    public static ErrorOr<UserRegistration> Create(UserRegistrationId id, string email)
    {
        var userRegistration = new UserRegistration(id, email, UserRegistrationStatus.Pending);

        return userRegistration;
    }

    public ErrorOr<Success> Confirm(string identityProviderId, string email, string firstName, string lastName)
    {
        if (Email != email)
        {
            return UserRegistrationErrors.EmailDoesNotMatch;
        }

        return Status switch
        {
            var status when status == UserRegistrationStatus.Confirmed => ConfirmUserRegistration(),
            var status when status == UserRegistrationStatus.Cancelled => CancelUserRegistration(),
            var status when status == UserRegistrationStatus.Expired => ExpiredUserRegistration(),
            _ => ConfirmInternal(identityProviderId, firstName, lastName)
        };
    }

    private ErrorOr<Success> ExpiredUserRegistration()
    {
        throw new NotImplementedException();
    }

    private ErrorOr<Success> CancelUserRegistration()
    {
        throw new NotImplementedException();
    }

    private ErrorOr<Success> ConfirmUserRegistration()
    {
        throw new NotImplementedException();
    }

    private Success ConfirmInternal(string identityProviderId, string firstName, string lastName)
    {
        IdentityProviderId = identityProviderId;
        FirstName = firstName;
        LastName = lastName;
        Status = UserRegistrationStatus.Confirmed;
        ConfirmedOnUtc = SystemTimeProvider.UtcNow();

        RaiseDomainEvent(new UserRegistrationConfirmedDomainEvent(
            DefaultIdType.NewGuid(),
            SystemTimeProvider.UtcNow(),
            Id));

        return Result.Success;
    }
}
