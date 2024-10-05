// <copyright file="RemoveCompetitionFromMeetCommandHandler.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Application.Competitions.Commands.RemoveCompetitionFromMeet;

internal sealed class RemoveCompetitionFromMeetCommandHandler(
  IUnitOfWork unitOfWork,
  IMeetRepository meetRepository,
  ICompetitionRepository competitionRepository)
  : ICommandHandler<RemoveCompetitionFromMeetCommand>
{
  private readonly IUnitOfWork _unitOfWork = unitOfWork;
  private readonly IMeetRepository _meetRepository = meetRepository;
  private readonly ICompetitionRepository _competitionRepository = competitionRepository;

  public async Task<Result> Handle(RemoveCompetitionFromMeetCommand request, CancellationToken cancellationToken)
  {
    var meet = await _meetRepository.GetAsync(request.MeetId, cancellationToken);

    if (meet is null)
    {
      return Result.Failure(MeetErrors.NotFound(request.MeetId));
    }

    var competition = await _competitionRepository.GetAsync(request.CompetitionId, cancellationToken);

    if (competition is null)
    {
      return Result.Failure(CompetitionErrors.NotFound(request.CompetitionId));
    }

    meet.RemoveCompetition(competition);

    await _unitOfWork.SaveChangesAsync(cancellationToken);

    return Result.Success();
  }
}
