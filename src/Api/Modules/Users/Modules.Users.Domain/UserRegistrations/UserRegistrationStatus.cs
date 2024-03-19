namespace Modules.Users.Domain.UserRegistrations;

/// <summary>
/// Represents the user registration status.
/// </summary>
public sealed class UserRegistrationStatus : SmartEnum<UserRegistrationStatus>
{
    /// <summary>
    /// Pending.
    /// </summary>
    public static readonly UserRegistrationStatus Pending = new (nameof(Pending), 1);

    /// <summary>
    /// Confirmed.
    /// </summary>
    public static readonly UserRegistrationStatus Confirmed = new (nameof(Confirmed), 2);

    /// <summary>
    /// Cancelled.
    /// </summary>
    public static readonly UserRegistrationStatus Cancelled = new (nameof(Cancelled), 3);

    /// <summary>
    /// Expired.
    /// </summary>
    public static readonly UserRegistrationStatus Expired = new (nameof(Expired), 4);

    /// <summary>
    /// Initializes a new instance of the <see cref="UserRegistrationStatus"/> class.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <param name="value">The value.</param>
    public UserRegistrationStatus(string name, int value)
        : base(name, value)
    {
    }
}
