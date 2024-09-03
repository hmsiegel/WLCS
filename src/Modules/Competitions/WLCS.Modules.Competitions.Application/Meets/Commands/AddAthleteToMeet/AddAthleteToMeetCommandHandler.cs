// <copyright file="AddAthleteToMeetCommandHandler.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Application.Meets.Commands.AddAthleteToMeet;

internal sealed class AddAthleteToMeetCommandHandler(
  IUnitOfWork unitOfWork,
  IMeetRepository meetRepository,
  IAthleteRepository athleteRepository)
  : ICommandHandler<AddAthleteToMeetCommand>
{
  private readonly IUnitOfWork _unitOfWork = unitOfWork;
  private readonly IMeetRepository _meetRepository = meetRepository;
  private readonly IAthleteRepository _athleteRepository = athleteRepository;

  public async Task<Result> Handle(AddAthleteToMeetCommand request, CancellationToken cancellationToken)
  {
    // 1. Get meet
    var meet = await _meetRepository.GetAsync(request.MeetId, cancellationToken);

    if (meet is null)
    {
      return Result.Failure(MeetErrors.NotFound(request.MeetId));
    }

    // 2. Get athlete
    var athlete = await _athleteRepository.GetAsync(request.AthleteId, cancellationToken);

    if (athlete is null)
    {
      return Result.Failure(AthleteErrors.NotFound(request.AthleteId));
    }

    athlete.AddToMeet(MeetId.Create(request.MeetId));

    // 3. Add athlete to meet
    _athleteRepository.Update(athlete);

    await _unitOfWork.SaveChangesAsync(cancellationToken);

    return Result.Success();
  }
}
