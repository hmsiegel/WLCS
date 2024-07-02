// <copyright file="BaseTest.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.UnitTests.Abstractions;

/// <summary>
/// Represents an abstract class that serves as the base class for all test classes.
/// </summary>
public abstract class BaseTest
{
  /// <summary>
  /// Represents an instance of the <see cref="Faker"/> class.
  /// </summary>
  protected static readonly Faker Faker = new();

  /// <summary>
  /// Method that asserts that a domain event of the specified type was published.
  /// </summary>
  /// <typeparam name="T">The type of the domain event.</typeparam>
  /// <param name="entity">The entity calling the domain event.</param>
  /// <returns>The domain event.</returns>
  /// <exception cref="Exception">An exception specifying that the domain event was not published.</exception>
  [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2201:Do not raise reserved exception types", Justification = "Reviewed")]
  public static T AssertDomainEventWasPublished<T>(Entity entity)
  {
    ArgumentNullException.ThrowIfNull(entity);
    T? domainEvent = entity.DomainEvents.OfType<T>().SingleOrDefault();

    return domainEvent is null
      ? throw new Exception($"Domain event of type {typeof(T)} was not published.")
      : domainEvent;
  }
}
