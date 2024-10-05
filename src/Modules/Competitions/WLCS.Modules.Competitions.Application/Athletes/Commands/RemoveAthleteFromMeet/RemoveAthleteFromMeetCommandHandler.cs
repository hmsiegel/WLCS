// <copyright file="RemoveAthleteFromMeetCommandHandler.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Application.Athletes.Commands.RemoveAthleteFromMeet;

internal sealed class RemoveAthleteFromMeetCommandHandler(
  IUnitOfWork unitOfWork,
  IMeetRepository meetRepository,
  IAthleteRepository athleteRepository)
  : ICommandHandler<RemoveAthleteFromMeetCommand>
{
  private readonly IUnitOfWork _unitOfWork = unitOfWork;
  private readonly IMeetRepository _meetRepository = meetRepository;
  private readonly IAthleteRepository _athleteRepository = athleteRepository;

  public async Task<Result> Handle(RemoveAthleteFromMeetCommand request, CancellationToken cancellationToken)
  {
    var meet = await _meetRepository.GetAsync(request.MeetId, cancellationToken);

    if (meet is null)
    {
      return Result.Failure(MeetErrors.NotFound(request.MeetId));
    }

    var athlete = await _athleteRepository.GetAsync(request.AthleteId, cancellationToken);

    if (athlete is null)
    {
      return Result.Failure(AthleteErrors.NotFound(request.AthleteId));
    }

    meet.RemoveAthlete(athlete);

    await _unitOfWork.SaveChangesAsync(cancellationToken);

    return Result.Success();
  }
}
