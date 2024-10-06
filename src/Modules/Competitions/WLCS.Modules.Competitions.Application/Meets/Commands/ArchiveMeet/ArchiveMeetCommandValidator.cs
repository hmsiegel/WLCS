// <copyright file="ArchiveMeetCommandValidator.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Application.Meets.Commands.ArchiveMeet;

internal sealed class ArchiveMeetCommandValidator : AbstractValidator<ArchiveMeetCommand>
{
  public ArchiveMeetCommandValidator()
  {
    RuleFor(x => x.MeetId).NotEmpty();
  }
}
