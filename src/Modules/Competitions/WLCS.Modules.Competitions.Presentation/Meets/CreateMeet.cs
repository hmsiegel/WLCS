// <copyright file="CreateMeet.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

using IMapper = MapsterMapper.IMapper;

namespace WLCS.Modules.Competitions.Presentation.Meets;

internal sealed class CreateMeet(
  ISender sender,
  IMapper mapper)
  : Endpoint<CreateMeetRequest, CreateMeetResponse>
{
  private readonly ISender _sender = sender;
  private readonly IMapper _mapper = mapper;

  public override void Configure()
  {
    Post("meets");
    Permissions(Presentation.Permissions.CreateMeet);
    Options(opt => opt.WithTags(Presentation.Tags.Meets));
  }

  public override async Task HandleAsync(CreateMeetRequest req, CancellationToken ct)
  {
    var command = new CreateMeetCommand(
      req.Name,
      req.City,
      req.State,
      req.Venue,
      req.StartDate,
      req.EndDate);

    var result = await _sender.Send(command, ct);

    if (result.IsSuccess)
    {
      await SendAsync(_mapper.Map<CreateMeetResponse>(result.Value), cancellation: ct);
    }
    else
    {
      await SendResultAsync(ApiResults.Problem(result));
    }
  }
}
