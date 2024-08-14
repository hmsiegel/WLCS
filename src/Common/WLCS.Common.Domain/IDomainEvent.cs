﻿// <copyright file="IDomainEvent.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Domain;

public interface IDomainEvent
{
  Guid Id { get; }

  DateTime OccurredOnUtc { get; }
}