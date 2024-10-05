// <copyright file="ListPlatformsByMeetQueryHandler.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Application.Platforms.Queries.ListPlatformsByMeet;

internal sealed class ListPlatformsByMeetQueryHandler(IPlatformRepository platformRepository) : IQueryHandler<ListPlatformsByMeetQuery, List<GetPlatformResponse>>
{
  private readonly IPlatformRepository _platformRepository = platformRepository;

  public async Task<Result<List<GetPlatformResponse>>> Handle(ListPlatformsByMeetQuery request, CancellationToken cancellationToken)
  {
    var result = await _platformRepository.GetByMeetId(request.MeetId, cancellationToken);

    if (result is null)
    {
      return Result.Failure<List<GetPlatformResponse>>(PlatformErrors.NoPlatformsFound);
    }

    var platforms = result.Select(p => new GetPlatformResponse(p.PlatformName.Value)).ToList();

    return platforms;
  }
}
