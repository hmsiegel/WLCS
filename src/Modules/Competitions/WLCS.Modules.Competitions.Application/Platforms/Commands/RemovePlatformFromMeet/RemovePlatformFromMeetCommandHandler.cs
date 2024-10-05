// <copyright file="RemovePlatformFromMeetCommandHandler.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Application.Platforms.Commands.RemovePlatformFromMeet;

internal sealed class RemovePlatformFromMeetCommandHandler(
  IUnitOfWork unitOfWork,
  IMeetRepository meetRepository,
  IPlatformRepository platformRepository)
  : ICommandHandler<RemovePlatformFromMeetCommand>
{
  private readonly IUnitOfWork _unitOfWork = unitOfWork;
  private readonly IMeetRepository _meetRepository = meetRepository;
  private readonly IPlatformRepository _platformRepository = platformRepository;

  public async Task<Result> Handle(RemovePlatformFromMeetCommand request, CancellationToken cancellationToken)
  {
    var meet = await _meetRepository.GetAsync(request.MeetId, cancellationToken);

    if (meet is null)
    {
      return Result.Failure(MeetErrors.NotFound(request.MeetId));
    }

    var platform = await _platformRepository.GetAsync(request.PlatformId, cancellationToken);

    if (platform is null)
    {
      return Result.Failure(PlatformErrors.NotFound(request.PlatformId));
    }

    meet.RemovePlatform(platform);

    await _unitOfWork.SaveChangesAsync(cancellationToken);

    return Result.Success();
  }
}
