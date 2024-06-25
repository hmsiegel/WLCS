// <copyright file="IIntegrationEvent.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Application.EventBus;

/// <summary>
/// Represents the <see cref="IIntegrationEvent"/> interface.
/// </summary>
public interface IIntegrationEvent
{
  /// <summary>
  /// Gets the identifier.
  /// </summary>
  Guid Id { get; }

  /// <summary>
  /// Gets the occurred on UTC.
  /// </summary>
  DateTime OccurredOnUtc { get; }
}
