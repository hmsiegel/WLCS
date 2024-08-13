// <copyright file="GetMeetsQueryHandler.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Application.Meets.Queries.GetMeets;

internal sealed class GetMeetsQueryHandler(IMeetRepository meetRepository)
  : IQueryHandler<GetMeetsQuery, IReadOnlyCollection<MeetResponse>>
{
  private readonly IMeetRepository _meetRepository = meetRepository;

  public async Task<Result<IReadOnlyCollection<MeetResponse>>> Handle(
    GetMeetsQuery request,
    CancellationToken cancellationToken)
  {
    var meets = await _meetRepository.GetAll(cancellationToken);

    var result = meets.Select(x => new MeetResponse(
      x.Id,
      x.Name,
      x.Location,
      x.Venue,
      x.StartDate,
      x.EndDate)).ToList();

    return result;
  }
}
