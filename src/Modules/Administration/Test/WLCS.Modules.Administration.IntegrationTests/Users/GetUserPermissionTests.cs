// <copyright file="GetUserPermissionTests.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;

namespace WLCS.Modules.Administration.IntegrationTests.Users;

public class GetUserPermissionTests(IntegrationTestWebAppFactory factory)
  : BaseIntegrationTest(factory)
{
  [Fact]
  public async Task Should_ReturnError_WhenUserDoesNotExistAsync()
  {
    // Arrange
    var identityId = Guid.NewGuid().ToString();

    // Act
    var permissionResult = await Sender.Send(new GetUserPermissionsQuery(identityId));

    // Assert
    permissionResult.Errors[0].Should().Be(UserErrors.NotFound(identityId));
  }

  [Fact]
  public async Task Should_ReturnPermissions_WhenUserExistsAsync()
  {
    // Arrange
    var result = await Sender.Send(new RegisterUserCommand(
      Faker.Internet.Email(),
      Faker.Internet.Password(),
      Faker.Name.FirstName(),
      Faker.Name.LastName()));

    var users = await DbContext.Users.ToListAsync();

    var identityId = users.SingleOrDefault(x => x.Id.Value == result.Value)!.IdentityId;

    // Act
    var permissionResult = await Sender.Send(new GetUserPermissionsQuery(identityId));

    // Assert
    permissionResult.IsSuccess.Should().BeTrue();
    permissionResult.Value.Permissions.Should().NotBeEmpty();
  }
}
