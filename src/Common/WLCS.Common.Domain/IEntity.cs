// <copyright file="IEntity.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Domain;

public interface IEntity
{
  void ClearDomainEvents();

  IReadOnlyCollection<IDomainEvent> GetDomainEvents();
}
