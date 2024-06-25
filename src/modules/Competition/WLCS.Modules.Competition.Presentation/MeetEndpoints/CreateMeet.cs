// <copyright file="CreateMeet.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competition.Presentation.MeetEndpoints;

/// <summary>
///  Represents the create meet endpoint.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="CreateMeet"/> class.
/// </remarks>
/// <param name="sender">A MediatR instance.</param>
internal sealed class CreateMeet(ISender sender) : Endpoint<CreateMeetRequest, Guid>
{
  private readonly ISender _sender = sender;

  /// <inheritdoc/>
  public override void Configure()
  {
    Post("competitions/meets");
    AllowAnonymous();
    Options(x => x.WithTags(Presentation.Tags.Competition));
  }

  /// <inheritdoc/>
  public override async Task HandleAsync(CreateMeetRequest request, CancellationToken cancellationToken)
  {
    ArgumentNullException.ThrowIfNull(request);

    var command = new CreateMeetCommand(
      request.Name,
      request.Location,
      request.Venue,
      request.StartDate,
      request.EndDate);

    var result = await _sender.Send(command, cancellationToken).ConfigureAwait(false);

    await SendResultAsync(result.Match(Results.Ok, ApiResults.Problem))
      .ConfigureAwait(false);
  }
}
