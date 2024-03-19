namespace Modules.Users.Domain.Users.Events;

/// <summary>
/// Represents the user changed domain event.
/// </summary>
/// <param name="Id">The id.</param>
/// <param name="OccurredOnUtc">The occurred on date and time.</param>
/// <param name="UserId">The user id.</param>
/// <param name="FirstName">The first name.</param>
/// <param name="LastName">The last name.</param>
/// <param name="Roles">The roles.</param>
public sealed record UserChangedDomainEvent(
    DefaultIdType Id,
    DateTime OccurredOnUtc,
    UserId UserId,
    string FirstName,
    string LastName,
    HashSet<string> Roles) : DomainEvent(Id, OccurredOnUtc);