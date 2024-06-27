// <copyright file="CreateMeet.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competition.Presentation.MeetEndpoints;

/// <summary>
///  Creates a meet.
/// </summary>
internal sealed class CreateMeet : IEndpoint
{
  /// <inheritdoc/>
  public void MapEndpoint(IEndpointRouteBuilder app)
  {
    app.MapPost("meets", async (CreateMeetRequest request, ISender sender) =>
    {
      var command = new CreateMeetCommand(
        request.Name,
        request.Location,
        request.Venue,
        request.StartDate,
        request.EndDate);

      var result = await sender.Send(command).ConfigureAwait(false);

      return result.Match(Results.Ok, ApiResults.Problem);
    })
    .RequireAuthorization("meet:create")
    .WithTags(Tags.Competition);
  }
}
