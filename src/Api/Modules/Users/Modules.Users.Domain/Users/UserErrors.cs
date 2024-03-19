namespace Modules.Users.Domain.Users;

/// <summary>
/// Contains the user errors.
/// </summary>
public static class UserErrors
{
    /// <summary>
    /// Gets the registration is not confirmed error.
    /// </summary>
    public static readonly Error RegistrationIsNotConfirmed = Error.Validation(
        code: "User.RegistrationIsNotConfirmed",
        description: "The user registration is not confirmed.");

    /// <summary>
    /// Gets the registration is incomplete error.
    /// </summary>
    public static readonly Error RegistrationIsIncomplete = Error.Validation(
       code: "User.RegistrationIsIncomplete",
       description: "The user registration is incomplete.");
}
