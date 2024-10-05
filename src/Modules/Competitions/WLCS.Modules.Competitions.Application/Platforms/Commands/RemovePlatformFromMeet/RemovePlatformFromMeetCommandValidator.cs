// <copyright file="RemovePlatformFromMeetCommandValidator.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Application.Platforms.Commands.RemovePlatformFromMeet;

internal sealed class RemovePlatformFromMeetCommandValidator : AbstractValidator<RemovePlatformFromMeetCommand>
{
  public RemovePlatformFromMeetCommandValidator()
  {
    RuleFor(x => x.MeetId).NotEmpty();
    RuleFor(x => x.PlatformId).NotEmpty();
  }
}
