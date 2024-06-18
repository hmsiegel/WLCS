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
    Tags(Presentation.Tags.Competition);
  }

  /// <inheritdoc/>
  public override async Task HandleAsync(CreateMeetRequest req, CancellationToken ct)
  {
    ArgumentNullException.ThrowIfNull(req);

    var command = new CreateMeetCommand(
      req.Name,
      req.Location,
      req.Venue,
      req.StartDate,
      req.EndDate);

    var result = await _sender.Send(command, ct).ConfigureAwait(false);

    await SendOkAsync(result, ct).ConfigureAwait(false);
  }
}
