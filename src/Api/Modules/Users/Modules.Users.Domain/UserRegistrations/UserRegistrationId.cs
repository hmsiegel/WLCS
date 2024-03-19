namespace Modules.Users.Domain.UserRegistrations;

/// <summary>
/// Represents the user registration id.
/// </summary>
/// <param name="Value">The value.</param>
public sealed record UserRegistrationId(DefaultIdType Value) : IEntityId;
