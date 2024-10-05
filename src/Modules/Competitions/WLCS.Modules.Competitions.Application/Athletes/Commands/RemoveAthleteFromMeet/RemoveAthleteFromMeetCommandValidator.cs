// <copyright file="RemoveAthleteFromMeetCommandValidator.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Application.Athletes.Commands.RemoveAthleteFromMeet;

internal sealed class RemoveAthleteFromMeetCommandValidator : AbstractValidator<RemoveAthleteFromMeetCommand>
{
  public RemoveAthleteFromMeetCommandValidator()
  {
    RuleFor(x => x.MeetId).NotEmpty();
    RuleFor(x => x.AthleteId).NotEmpty();
  }
}
