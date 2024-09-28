// <copyright file="GetMeet.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

using IMapper = MapsterMapper.IMapper;

namespace WLCS.Modules.Competitions.Presentation.Meets;

internal sealed class GetMeet(ISender sender, IMapper mapper) : Endpoint<GetMeetRequest, MeetResponse>
{
  private readonly ISender _sender = sender;
  private readonly IMapper _mapper = mapper;

  public override void Configure()
  {
    Get("meets/{id}");
    Permissions(Presentation.Permissions.GetMeets);
    Options(x => x.WithTags(Presentation.Tags.Meets));
  }

  public override async Task HandleAsync(GetMeetRequest req, CancellationToken ct)
  {
    var query = new GetMeetQuery(req.Id);
    var result = await _sender.Send(query, ct);

    if (result.IsSuccess)
    {
      await SendAsync(_mapper.Map<MeetResponse>(result), statusCode: StatusCodes.Status200OK, ct);
    }
    else
    {
      await SendResultAsync(ApiResults.Problem(result));
    }
  }
}
