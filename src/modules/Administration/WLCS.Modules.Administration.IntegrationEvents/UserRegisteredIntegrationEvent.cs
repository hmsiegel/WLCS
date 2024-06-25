// <copyright file="UserRegisteredIntegrationEvent.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

using WLCS.Common.Application.EventBus;

namespace WLCS.Modules.Administration.IntegrationEvents;

/// <summary>
/// Represents the <see cref="UserRegisteredIntegrationEvent"/> class.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="UserRegisteredIntegrationEvent"/> class.
/// </remarks>
/// <param name="userId">The user Id.</param>
/// <param name="email">The email of the user.</param>
/// <param name="firstName">The first name of the user.</param>
/// <param name="lastName">The last name of the user.</param>
/// <param name="id">The ID of the event.</param>
/// <param name="occurredOnUtc">The date and time the event occurred.</param>
public sealed class UserRegisteredIntegrationEvent(
  Guid userId,
  string email,
  string firstName,
  string lastName,
  Guid id,
  DateTime occurredOnUtc) : IntegrationEvent(id, occurredOnUtc)
{
  /// <summary>
  /// Gets the user Id.
  /// </summary>
  public Guid UserId { get; init; } = userId;

  /// <summary>
  /// Gets the email of the user.
  /// </summary>
  public string Email { get; init; } = email;

  /// <summary>
  /// Gets the first name of the user.
  /// </summary>
  public string FirstName { get; init; } = firstName;

  /// <summary>
  /// Gets the last name of the user.
  /// </summary>
  public string LastName { get; init; } = lastName;
}
