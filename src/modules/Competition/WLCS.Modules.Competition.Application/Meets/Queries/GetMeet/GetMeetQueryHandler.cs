// <copyright file="GetMeetQueryHandler.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competition.Application.Meets.Queries.GetMeet;

/// <summary>
/// Represents a query to get a meet.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="GetMeetQueryHandler"/> class.
/// </remarks>
/// <param name="meetRepository">An instance of the meet repository.</param>
internal sealed class GetMeetQueryHandler(IMeetRepository meetRepository)
    : IQueryHandler<GetMeetQuery, MeetResponse>
{
  private readonly IMeetRepository _meetRepository = meetRepository;

  /// <inheritdoc/>
  public async Task<Result<MeetResponse>> Handle(GetMeetQuery request, CancellationToken cancellationToken)
  {
    var meet = await _meetRepository.GetByIdAsync(request.MeetId, cancellationToken);

    if (meet is null)
    {
      return Result.Failure<MeetResponse>(MeetErrors.MeetNotFound);
    }

    var result = new MeetResponse
    {
      Id = meet.Id,
      Name = meet.Name,
      Venue = meet.Venue,
      StartDate = meet.StartDate,
      EndDate = meet.EndDate,
      Location = meet.Location,
    };

    return result;
  }
}
