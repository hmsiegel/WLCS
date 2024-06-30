// <copyright file="GetUserPermissionsTests.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.IntegrationTests.Users;

/// <summary>
/// Tests for the GetUserPermissions method.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="GetUserPermissionsTests"/> class.
/// </remarks>
/// <param name="factory">An instance of the <see cref="IntegrationTestWebAppFactory"/>.</param>
public class GetUserPermissionsTests(IntegrationTestWebAppFactory factory)
  : BaseIntegrationTest(factory)
{
  /// <summary>
  /// Asserts that the GetUserPermissions method should return an error when the user does not exist.
  /// </summary>
  /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
  [Fact]
  public async Task Should_ReturnError_WhenUserDoesNotExistAsync()
  {
    // Arrange
    var identityId = Guid.NewGuid().ToString();

    // Act
    var result = await Sender.Send(new GetUserPermissionsQuery(identityId));

    // Assert
    result.Error.Should().Be(UserErrors.NotFound(identityId));
  }

  /// <summary>
  /// Asserts that the GetUserPermissions method should return the permissions when the user exists.
  /// </summary>
  /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
  [Fact]
  public async Task Should_ReturnPermissions_WhenUserExistsAsync()
  {
    // Arrange
    var command = new RegisterUserCommand(
      Faker.Internet.Email(),
      Faker.Internet.Password(),
      Faker.Name.FirstName(),
      Faker.Name.LastName());
    var result = await Sender.Send(command);

    var identityId = DbContext.Users.Single(u => u.Id == result.Value).IdentityId;

    // Act
    var permissionsResult = await Sender.Send(new GetUserPermissionsQuery(identityId));

    // Assert
    permissionsResult.IsSuccess.Should().BeTrue();
    permissionsResult.Value.Permissions.Should().NotBeEmpty();
  }
}
