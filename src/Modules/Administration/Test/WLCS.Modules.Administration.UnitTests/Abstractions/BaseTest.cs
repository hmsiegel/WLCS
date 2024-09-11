// <copyright file="BaseTest.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.UnitTests.Abstractions;

public abstract class BaseTest
{
  protected static readonly Faker Faker = new();

  public static T AssertDomainEventWasPublished<T>(Entity entity)
    where T : IDomainEvent
  {
    ArgumentNullException.ThrowIfNull(entity);

    T? domainEvent = entity.GetDomainEvents().OfType<T>().SingleOrDefault();

    return domainEvent is null
      ? throw new ArgumentNullException($"{typeof(T).Name} was not published")
      : domainEvent;
  }
}
