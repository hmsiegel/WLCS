// <copyright file="DomainTests.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.ArchitectureTests.Domain;

public class DomainTests : BaseTest
{
  [Fact]
  public void DomainEvents_Should_BeSealed()
  {
    Types.InAssembly(DomainAssembly)
      .That()
      .Inherit(typeof(DomainEvent))
      .Should()
      .BeSealed()
      .GetResult()
      .ShouldBeSuccessful();
  }

  [Fact]
  public void DomainEvents_ShouldHave_NameEndingWith_DomainEvents()
  {
    Types.InAssembly(DomainAssembly)
      .That()
      .Inherit(typeof(DomainEvent))
      .Should()
      .HaveNameEndingWith("DomainEvent", StringComparison.InvariantCulture)
      .GetResult()
      .ShouldBeSuccessful();
  }

  [Fact]
  public void Entities_ShouldHave_PrivateParameterlessConstructor()
  {
    var entityTypes = Types.InAssembly(DomainAssembly)
      .That()
      .Inherit(typeof(Entity))
      .GetTypes();

    var failingTypes = new List<Type>();

    foreach (var entityType in entityTypes)
    {
      var constructors = entityType.GetConstructors(BindingFlags.Instance
                                                    | BindingFlags.NonPublic);

      if (!Array.Exists(constructors, c => c.IsPrivate && c.GetParameters().Length == 0))
      {
        failingTypes.Add(entityType);
      }
    }

    failingTypes.Should().BeEmpty();
  }

  [Fact]
  public void Entities_ShouldOnlyHave_PrivateConstructors()
  {
    var entityTypes = Types.InAssembly(DomainAssembly)
      .That()
      .Inherit(typeof(Entity))
      .GetTypes();

    var failingTypes = new List<Type>();

    foreach (var entityType in entityTypes)
    {
      var constructors = entityType.GetConstructors(BindingFlags.Instance
                                                    | BindingFlags.Public);

      if (constructors.Length != 0)
      {
        failingTypes.Add(entityType);
      }
    }

    failingTypes.Should().BeEmpty();
  }
}
