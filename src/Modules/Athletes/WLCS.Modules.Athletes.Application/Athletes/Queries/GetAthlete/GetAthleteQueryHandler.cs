// <copyright file="GetAthleteQueryHandler.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Athletes.Application.Athletes.Queries.GetAthlete;

internal sealed class GetAthleteQueryHandler(IAthleteRepository athleteRepository) : IQueryHandler<GetAthleteQuery, AthleteResponse>
{
  private readonly IAthleteRepository _athleteRepository = athleteRepository;

  public async Task<Result<AthleteResponse>> Handle(GetAthleteQuery request, CancellationToken cancellationToken)
  {
    var athlete = await _athleteRepository.GetAsync(request.AthleteId, cancellationToken);

    if (athlete is null)
    {
      return Result.Failure<AthleteResponse>(AthleteErrors.NotFound(request.AthleteId));
    }

    var result = new AthleteResponse(
      athlete.Id.Value,
      athlete.Membership.MembershipId,
      athlete.FirstName.Value,
      athlete.LastName.Value,
      athlete.Email.Value,
      athlete.Gender.ToString(),
      athlete.DateOfBirth);

    return result;
  }
}
