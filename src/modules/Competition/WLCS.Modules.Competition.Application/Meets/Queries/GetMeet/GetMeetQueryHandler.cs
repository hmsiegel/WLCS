// <copyright file="GetMeetQueryHandler.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

using System.Data.Common;
using Dapper;

namespace WLCS.Modules.Competition.Application.Meets.Queries.GetMeet;

/// <summary>
/// Represents a query to get a meet.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="GetMeetQueryHandler"/> class.
/// </remarks>
/// <param name="meetRepository">An instance of the meet repository.</param>
internal sealed class GetMeetQueryHandler(IMeetRepository meetRepository) : IRequestHandler<GetMeetQuery, MeetResponse>
{
  private readonly IMeetRepository _meetRepository = meetRepository;

  /// <summary>
  /// Handles the request.
  /// </summary>
  /// <param name="request">The <see cref="GetMeetQuery"/>.</param>
  /// <param name="cancellationToken">The cancellation token.</param>
  /// <returns>The meet.</returns>
  /// <exception cref="NullReferenceException">Thrown if the meet doesn not exist.</exception>
  public async Task<MeetResponse> Handle(GetMeetQuery request, CancellationToken cancellationToken)
  {
    var meet = await _meetRepository.GetByIdAsync(request.MeetId, cancellationToken).ConfigureAwait(false);

    var result = new MeetResponse(
      meet!.Id,
      meet.Name,
      meet.Location,
      meet.Venue,
      meet.StartDate,
      meet.EndDate);

    return result;
  }
}
