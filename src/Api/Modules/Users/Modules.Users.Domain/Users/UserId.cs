namespace Modules.Users.Domain.Users;

/// <summary>
/// Represents the user Id.
/// </summary>
/// <param name="Value">The value.</param>
public sealed record UserId(DefaultIdType Value) : IEntityId;
