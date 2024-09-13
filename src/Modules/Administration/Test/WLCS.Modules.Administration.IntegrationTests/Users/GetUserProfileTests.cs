// <copyright file="GetUserProfileTests.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

using System.Net.Http.Headers;

using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace WLCS.Modules.Administration.IntegrationTests.Users;

public class GetUserProfileTests(IntegrationTestWebAppFactory factory)
  : BaseIntegrationTest(factory)
{
  [Fact]
  public async Task Should_ReturnUnauthorized_WhenAccessTokenNotProvidedAsync()
  {
    // Act
    var response = await HttpClient.GetAsync(new Uri("http://localhost:5001/users/profile"));

    // Assert
    response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
  }

  [Fact]
  public async Task Should_ReturnUserProfile_WhenAccessTokenProvidedAsync()
  {
    // Arrange
    var accessToken = await RegisterUserAndGetAccessTokenAsync("exists@test.com", Faker.Internet.Password());
    HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
      JwtBearerDefaults.AuthenticationScheme,
      accessToken);

    // Act
    var response = await HttpClient.GetAsync(new Uri("http://localhost:5001/users/profile"));

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

    var accessToken = await GetAccessTokenAsync(request.Email, request.Password);

    return accessToken;
  }
}
