// <copyright file="GetMeetEndpoint.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

using MeetResponse = WLCS.Modules.Competition.Presentation.MeetEndpoints.MeetResponse;

namespace WLCS.Modules.Competition.Presentation.Meets;

/// <summary>
/// The request to get a meet.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="GetMeetEndpoint"/> class.
/// </remarks>
/// <param name="sender">The MediatR instance.</param>
internal sealed class GetMeetEndpoint(ISender sender) : EndpointWithoutRequest<MeetResponse>
{
  private readonly ISender _sender = sender;

  /// <inheritdoc/>
  public override void Configure()
  {
    Get("competitions/meets/{Id}");
    AllowAnonymous();
    Tags(Presentation.Tags.Competition);
  }

  /// <inheritdoc/>
  public override async Task HandleAsync(CancellationToken ct)
  {
    var meetId = Route<Guid>("Id");

    var query = new GetMeetQuery(meetId);

    var result = await _sender
      .Send(query, ct)
      .ConfigureAwait(false);

    var response = new MeetResponse(
      result.Id,
      result.Name,
      result.Location,
      result.Venue,
      result.StartDate,
      result.EndDate);

    await SendOkAsync(response, ct).ConfigureAwait(false);
  }
}
