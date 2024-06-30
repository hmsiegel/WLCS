// <copyright file="DomainTests.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Athletes.ArchitectureTests.Domain;

/// <summary>
/// Contains tests for the domain layer.
/// </summary>
public class DomainTests : BaseTest
{
  /// <summary>
  /// Asserts that domain events are sealed.
  /// </summary>
  [Fact]
  public void DomainEvents_Should_BeSealed()
  {
    Types.InAssembly(DomainAssembly)
      .That()
      .ImplementInterface(typeof(IDomainEvent))
      .Or()
      .Inherit(typeof(DomainEvent))
      .Should()
      .BeSealed()
      .GetResult()
      .ShouldBeSuccessful();
  }

  /// <summary>
  /// Asserts that domain events should end with "DomainEvent".
  /// </summary>
  [Fact]
  public void DomainEvents_ShouldHave_DomainEventPostFix()
  {
    Types.InAssembly(DomainAssembly)
      .That()
      .ImplementInterface(typeof(IDomainEvent))
      .Or()
      .Inherit(typeof(DomainEvent))
      .Should()
      .HaveNameEndingWith("DomainEvent", StringComparison.InvariantCultureIgnoreCase)
      .GetResult()
      .ShouldBeSuccessful();
  }

  /// <summary>
  /// Asserts that entities should have a private parameterless constructor.
  /// </summary>
  [Fact]
  public void Entities_ShouldHave_PrivateParameterlessContructor()
  {
    var entityTypes = Types.InAssembly(DomainAssembly)
      .That()
      .Inherit(typeof(Entity))
      .GetTypes();

    var failingTypes = new List<Type>();
    foreach (var entityType in entityTypes)
    {
      var constructors = entityType.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance);
      if (!constructors.Any(x => x.IsPrivate && x.GetParameters().Length == 0))
      {
        failingTypes.Add(entityType);
      }
    }

    failingTypes.Should().BeEmpty();
  }

  /// <summary>
  /// Asserts that entities should only have private constructors.
  /// </summary>
  [Fact]
  public void Entities_ShouldOnlyHave_PrivateContructors()
  {
    var entityTypes = Types.InAssembly(DomainAssembly)
      .That()
      .Inherit(typeof(Entity))
      .GetTypes();

    var failingTypes = new List<Type>();
    foreach (var entityType in entityTypes)
    {
      var constructors = entityType.GetConstructors(BindingFlags.Public | BindingFlags.Instance);
      if (constructors.Length != 0)
      {
        failingTypes.Add(entityType);
      }
    }

    failingTypes.Should().BeEmpty();
  }
}
