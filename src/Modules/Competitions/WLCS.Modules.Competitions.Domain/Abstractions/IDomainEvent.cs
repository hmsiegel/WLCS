// <copyright file="Meet.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Domain.Abstractions;

public interface IDomainEvent
{
  Guid Id { get; }

  DateTime OccurredOnUtc { get; }
}
