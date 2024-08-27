// <copyright file="GetMeetQueryHandler.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Application.Meets.Queries.GetMeet;

internal sealed class GetMeetQueryHandler(IMeetRepository meetRepository)
  : IQueryHandler<GetMeetQuery, MeetResponse>
{
  private readonly IMeetRepository _meetRepository = meetRepository;

  public async Task<Result<MeetResponse>> Handle(GetMeetQuery request, CancellationToken cancellationToken)
  {
    var meet = await _meetRepository.GetAsync(request.Id, cancellationToken);

    if (meet is null)
    {
      return Result.Failure<MeetResponse>(MeetErrors.NotFound(request.Id));
    }

    var result = new MeetResponse(
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
