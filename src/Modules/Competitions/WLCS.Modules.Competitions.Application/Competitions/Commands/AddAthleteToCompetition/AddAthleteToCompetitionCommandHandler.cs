// <copyright file="AddAthleteToCompetitionCommandHandler.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Application.Competitions.Commands.AddAthleteToCompetition;

internal sealed class AddAthleteToCompetitionCommandHandler(ICompetitionRespository competitionRepository, IAthleteApi athleteApi)
  : ICommandHandler<AddAthleteToCompetitionCommand>
{
  private readonly ICompetitionRespository _competitionRepository = competitionRepository;
  private readonly IAthleteApi _athleteApi = athleteApi;

  public async Task<Result> Handle(AddAthleteToCompetitionCommand request, CancellationToken cancellationToken)
  {
    var competition = await _competitionRepository.GetAsync(request.CompetitionId, cancellationToken);

    if (competition is null)
    {
      return Result.Failure(CompetitionErrors.NotFound(request.CompetitionId));
    }

    var athlete = await _athleteApi.GetAsync(request.AthleteId, cancellationToken);

    if (athlete is null)
    {
      return Result.Failure(AthleteErrors.NotFound(request.AthleteId));
    }

    var result = Athlete.Create(
      athlete.Id,
      competition.MeetId,
      athlete.MembershipId,
      athlete.FirstName,
      athlete.LastName,
      athlete.DateOfBirth,
      Gender.FromName(athlete.Gender));

    competition.AddAthlete(result);

    _competitionRepository.Update(competition);

    return Result.Success();
  }
}
