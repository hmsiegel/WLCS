// <copyright file="RemoveCompetitionFromMeetCommandValidator.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Application.Competitions.Commands.RemoveCompetitionFromMeet;

internal sealed class RemoveCompetitionFromMeetCommandValidator : AbstractValidator<RemoveCompetitionFromMeetCommand>
{
  public RemoveCompetitionFromMeetCommandValidator()
  {
    RuleFor(x => x.MeetId).NotNull();
    RuleFor(x => x.CompetitionId).NotNull();
  }
}
