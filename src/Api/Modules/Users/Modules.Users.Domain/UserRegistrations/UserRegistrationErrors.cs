namespace Modules.Users.Domain.UserRegistrations;

/// <summary>
/// Represents user registration errors.
/// </summary>
public static class UserRegistrationErrors
{
    /// <summary>
    /// Gets the email does not match error.
    /// </summary>
    public static readonly Error EmailDoesNotMatch = Error.Validation(
        code: "UserRegistration.EmailDoesNotMatch",
        description: "The email does not match the user registration email.");
}
