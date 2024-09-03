// <copyright file="EntityT.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Domain;

public abstract class Entity<TEntityId> : Entity
  where TEntityId : class
{
  protected Entity(TEntityId id)
  {
    Id = id;
  }

  protected Entity()
  {
  }

  public TEntityId Id { get; init; } = default!;
}
