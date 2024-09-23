// <copyright file="AddAthleteToMeetCommandValidator.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Application.Meets.Commands.AddAthleteToMeet;

internal sealed class AddAthleteToMeetCommandValidator : CustomValidator<AddAthleteToMeetCommand>
{
  public AddAthleteToMeetCommandValidator()
  {
    RuleFor(x => x.MeetId).NotEmpty();
    RuleFor(x => x.AthleteId).NotEmpty();
  }
}
