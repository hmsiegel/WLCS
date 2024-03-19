namespace Modules.Users.Domain.UserRegistrations.Events;

/// <summary>
/// Represents the domain event that is raised when a user registration is confirmed.
/// </summary>
/// <param name="Id">The Id.</param>
/// <param name="OccurredOnUtc">The occurred on date and time.</param>
/// <param name="UserRegistrationId">The user registration id.</param>
public sealed record UserRegistrationConfirmedDomainEvent(
    DefaultIdType Id,
    DateTime OccurredOnUtc,
    UserRegistrationId UserRegistrationId) : DomainEvent(Id, OccurredOnUtc);