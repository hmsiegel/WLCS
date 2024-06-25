// <copyright file="IntegrationEvent.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Application.EventBus;

/// <inheritdoc/>
/// <summary>
/// Initializes a new instance of the <see cref="IntegrationEvent"/> class.
/// </summary>
/// <param name="id">The unique identifier of the integration event.</param>
/// <param name="occurredOnUtc">The date and time the event occurred.</param>
public abstract class IntegrationEvent(Guid id, DateTime occurredOnUtc) : IIntegrationEvent
{
  /// <inheritdoc/>
  public Guid Id { get; init; } = id;

  /// <inheritdoc/>
  public DateTime OccurredOnUtc { get; init; } = occurredOnUtc;
}
