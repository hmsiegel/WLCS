// <copyright file="AddAthleteToMeetCommandHandler.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Application.Meets.Commands.AddAthleteToMeet;

internal sealed class AddAthleteToMeetCommandHandler(
  IUnitOfWork unitOfWork,
  IMeetRepository meetRepository,
  IAthleteApi athleteApi,
  IAthleteRepository athleteRepository)
  : ICommandHandler<AddAthleteToMeetCommand>
{
  private readonly IUnitOfWork _unitOfWork = unitOfWork;
  private readonly IMeetRepository _meetRepository = meetRepository;
  private readonly IAthleteApi _athleteApi = athleteApi;
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
    var athleteResponse = await _athleteApi.GetAsync(request.AthleteId, cancellationToken);

    if (athleteResponse is null)
    {
      return Result.Failure(AthleteErrors.NotFound(request.AthleteId));
    }

    var athlete = Athlete.Create(
      athleteResponse.Id,
      meet.Id,
      athleteResponse.MembershipId,
      athleteResponse.FirstName,
      athleteResponse.LastName,
      athleteResponse.DateOfBirth,
      Gender.FromName(athleteResponse.Gender));

    // 3. Add athlete to meet
    _athleteRepository.Add(athlete);

    await _unitOfWork.SaveChangesAsync(cancellationToken);

    return Result.Success();
  }
}
