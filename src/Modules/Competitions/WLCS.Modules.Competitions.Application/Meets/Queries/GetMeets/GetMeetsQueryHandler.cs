// <copyright file="GetMeetsQueryHandler.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Application.Meets.Queries.GetMeets;

internal sealed class GetMeetsQueryHandler(IMeetRepository meetRepository)
  : IQueryHandler<GetMeetsQuery, IReadOnlyCollection<GetMeetResponse>>
{
  private readonly IMeetRepository _meetRepository = meetRepository;

  public async Task<Result<IReadOnlyCollection<GetMeetResponse>>> Handle(
    GetMeetsQuery request,
    CancellationToken cancellationToken)
  {
    var meets = await _meetRepository.GetAll(cancellationToken);

    var result = meets.Select(x => new GetMeetResponse(
      x.Id.Value,
      x.Name.Value,
      x.Location.City,
      x.Location.State,
      x.Venue.Value,
      x.StartDate,
      x.EndDate)).ToList();

    return result;
  }
}
