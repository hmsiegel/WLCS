// <copyright file="CommandHelpers.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.IntegrationTests.Abstractions;

/// <summary>
/// Helper methods.
/// </summary>
internal static class CommandHelpers
{
  /// <summary>
  /// Creates a meet.
  /// </summary>
  /// <param name="sender">An implementation of ISender.</param>
  /// <returns>An asynchrounous task.</returns>
  internal static async Task CreateMeetAsync(this ISender sender)
  {
    var faker = new Faker();

    var result = await sender.Send(new CreateMeetCommand(
      faker.Company.CompanyName(),
      faker.Address.City(),
      faker.Company.CompanyName(),
      LocalDate.FromDateTime(DateTime.Now),
      LocalDate.FromDateTime(DateTime.Now.AddDays(1))));

    result.IsSuccess.Should().BeTrue();
  }
}
