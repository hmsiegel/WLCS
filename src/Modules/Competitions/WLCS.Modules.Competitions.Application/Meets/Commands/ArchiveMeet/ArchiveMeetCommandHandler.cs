// <copyright file="ArchiveMeetCommandHandler.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Application.Meets.Commands.ArchiveMeet;

internal sealed class ArchiveMeetCommandHandler(
  IUnitOfWork unitOfWork,
  IMeetRepository meetRepository)
  : ICommandHandler<ArchiveMeetCommand>
{
  private readonly IUnitOfWork _unitOfWork = unitOfWork;
  private readonly IMeetRepository _meetRepository = meetRepository;

  public async Task<Result> Handle(ArchiveMeetCommand command, CancellationToken cancellationToken)
  {
    var meet = await _meetRepository.GetAsync(command.MeetId, cancellationToken);

    if (meet is null)
    {
      return Result.Failure(MeetErrors.NotFound(command.MeetId));
    }

    meet.ArchiveMeet();

    await _unitOfWork.SaveChangesAsync(cancellationToken);

    return Result.Success();
  }
}
