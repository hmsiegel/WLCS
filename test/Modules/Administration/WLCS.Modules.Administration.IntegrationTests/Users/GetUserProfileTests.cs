// <copyright file="GetUserProfileTests.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.IntegrationTests.Users;

/// <summary>
/// Test class for the GetUserProfile method.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="GetUserProfileTests"/> class.
/// </remarks>
/// <param name="factory">An instance of the <see cref="IntegrationTestWebAppFactory"/>.</param>
public class GetUserProfileTests(IntegrationTestWebAppFactory factory)
  : BaseIntegrationTest(factory)
{
  /// <summary>
  /// Asserts that the GetUserProfile method returns a 401 Unauthorized status code when the access token is missing.
  /// </summary>
  /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
  [Fact]
  public async Task Should_ReturnUnauthorized_WhenAccessTokenIsMissingAsync()
  {
    // Act
    var response = await HttpClient.GetAsync(new Uri("users/profile", UriKind.Relative));

    // Assert
    response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
  }

  /// <summary>
  /// Asserts that the GetUserProfile method returns a 200 Ok status code when the user exists.
  /// </summary>
  /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
  [Fact]
  public async Task Should_ReturnOk_WhenUserExistsAsync()
  {
    // Arrange
    var accessToken = await RegisterUserAndGetAccessTokenAsync("exists@test.com", Faker.Internet.Password());
    HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
      JwtBearerDefaults.AuthenticationScheme,
      accessToken);

    // Act
    var response = await HttpClient.GetAsync(new Uri("users/profile", UriKind.Relative));

    // Assert
    response.StatusCode.Should().Be(HttpStatusCode.OK);

    var user = await response.Content.ReadFromJsonAsync<UserResponse>();
    user.Should().NotBeNull();
  }

  private async Task<string> RegisterUserAndGetAccessTokenAsync(string email, string password)
  {
    var request = new RegisterUser.Request(
      email,
      password,
      Faker.Name.FirstName(),
      Faker.Name.LastName());

    await HttpClient.PostAsJsonAsync("users/register", request);

    var accessToken = await GetAccessTokenAsync(email, password);

    return accessToken;
  }
}
