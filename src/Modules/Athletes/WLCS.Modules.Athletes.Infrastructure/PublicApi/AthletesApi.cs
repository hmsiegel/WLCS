// <copyright file="AthletesApi.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

using AthleteResponse = WLCS.Modules.Athletes.PublicApi.AthleteResponse;

namespace WLCS.Modules.Athletes.Infrastructure.PublicApi;

internal sealed class AthletesApi(ISender sender) : IAthleteApi
{
  private readonly ISender _sender = sender;

  public async Task<AthleteResponse?> GetAsync(Guid userId, CancellationToken cancellationToken = default)
  {
    var query = new GetAthleteQuery(userId);
    Result<Application.Athletes.Queries.GetAthlete.AthleteResponse> result =
      await _sender.Send(query, cancellationToken);

    if (result.IsFailure)
    {
      return null;
    }

    return new AthleteResponse(
      result.Value.Id,
      result.Value.MembershipId,
      result.Value.FirstName,
      result.Value.LastName,
      result.Value.Email,
      result.Value.Gender,
      result.Value.DateOfBirth);
  }
}
