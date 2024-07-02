// <copyright file="UserTests.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

using FluentAssertions;

using WLCS.Modules.Administration.Domain.Users;
using WLCS.Modules.Administration.Domain.Users.DomainEvents;
using WLCS.Modules.Administration.UnitTests.Abstractions;

namespace WLCS.Modules.Administration.UnitTests.Users;

/// <summary>
/// Test class that represents the unit tests for the <see cref="User"/> class.
/// </summary>
public class UserTests : BaseTest
{
  /// <summary>
  /// Asserts that the <see cref="User.Create(string, string, string, string)"/> method returns a user.
  /// </summary>
  [Fact]
  public void Create_ShouldReturnUser()
  {
    // Act
    var user = User.Create(
      Faker.Internet.Email(),
      Faker.Name.FirstName(),
      Faker.Name.LastName(),
      Guid.NewGuid().ToString());

    // Assert
    user.Should().NotBeNull();
  }

  /// <summary>
  /// Asserts that the <see cref="User.Create(string, string, string, string)"/> method returns a user with the member role.
  /// </summary>
  [Fact]
  public void Create_ShouldReturnUser_WithMemberRole()
  {
    // Act
    var user = User.Create(
      Faker.Internet.Email(),
      Faker.Name.FirstName(),
      Faker.Name.LastName(),
      Guid.NewGuid().ToString());

    // Assert
    user.Roles.Single().Should().Be(Role.User);
  }

  /// <summary>
  /// Asserts that the <see cref="User.Create(string, string, string, string)"/> method raises a domain event when a user is created.
  /// </summary>
  [Fact]
  public void Create_ShouldRaiseDomainEvent_WhenUserCreated()
  {
    // Act
    var user = User.Create(
      Faker.Internet.Email(),
      Faker.Name.FirstName(),
      Faker.Name.LastName(),
      Guid.NewGuid().ToString());

    // Assert
    var domainEvent = AssertDomainEventWasPublished<UserRegisteredDomainEvent>(user);

    domainEvent.UserId.Should().Be(user.Id);
  }

  /// <summary>
  /// Asserts that the <see cref="User.Update(string, string)"/> method raises a domain event when a user is updated.
  /// </summary>
  [Fact]
  public void Update_ShouldRaiseDomainEvent_WhenUserUpdated()
  {
    // Arrange
    var user = User.Create(
      Faker.Internet.Email(),
      Faker.Name.FirstName(),
      Faker.Name.LastName(),
      Guid.NewGuid().ToString());

    // Act
    user.Update(
      Faker.Name.FirstName(),
      Faker.Name.LastName());

    // Assert
    // Assert
    var domainEvent = AssertDomainEventWasPublished<UserProfileUpdatedDomainEvent>(user);

    domainEvent.UserId.Should().Be(user.Id);
    domainEvent.FirstName.Should().Be(user.FirstName);
    domainEvent.LastName.Should().Be(user.LastName);
  }

  /// <summary>
  /// Asserts that the <see cref="User.Update(string, string)"/> method does not raise a domain event when a user is not updated.
  /// </summary>
  [Fact]
  public void Update_ShouldNotRaiseDomainEvent_WhenUserNotUpdated()
  {
    // Arrange
    var user = User.Create(
      Faker.Internet.Email(),
      Faker.Name.FirstName(),
      Faker.Name.LastName(),
      Guid.NewGuid().ToString());

    user.ClearDomainEvents();

    // Act
    user.Update(user.FirstName, user.LastName);

    // Assert
    user.DomainEvents.Should().BeEmpty();
  }
}
