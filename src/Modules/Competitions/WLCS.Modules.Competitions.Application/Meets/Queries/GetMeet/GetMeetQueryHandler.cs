// <copyright file="GetMeetQueryHandler.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Application.Meets.Queries.GetMeet;

internal sealed class GetMeetQueryHandler(IMeetRepository meetRepository)
  : IQueryHandler<GetMeetQuery, GetMeetResponse>
{
  private readonly IMeetRepository _meetRepository = meetRepository;

  public async Task<Result<GetMeetResponse>> Handle(GetMeetQuery request, CancellationToken cancellationToken)
  {
    var meet = await _meetRepository.GetAsync(request.Id, cancellationToken);

    if (meet is null)
    {
      return Result.Failure<GetMeetResponse>(MeetErrors.NotFound(request.Id));
    }

    var result = new GetMeetResponse(
      meet.Id.Value,
      meet.Name.Value,
      meet.Location.City,
      meet.Location.State,
      meet.Venue.Value,
      meet.StartDate,
      meet.EndDate);

    return result;
  }
}
