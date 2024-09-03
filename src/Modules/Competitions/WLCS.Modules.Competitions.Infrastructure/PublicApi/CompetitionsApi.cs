// <copyright file="CompetitionsApi.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Infrastructure.PublicApi;

internal sealed class CompetitionsApi(ISender sender) : ICompetitionsApi
{
  private readonly ISender _sender = sender;

  public async Task CreateAthleteAsync(
    Guid athleteId,
    string membership,
    string firstName,
    string lastName,
    DateOnly dateOfBirth,
    string gender,
    CancellationToken cancellationToken = default)
  {
    await _sender.Send(
      new CreateAthleteCommand(
        athleteId,
        membership,
        firstName,
        lastName,
        dateOfBirth,
        gender),
      cancellationToken);
  }
}
