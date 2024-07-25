// <copyright file="CreateMeetCommandValidator.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Application.Meets.Commands.CreateMeet;

internal sealed class CreateMeetCommandValidator : AbstractValidator<CreateMeetCommand>
{
  public CreateMeetCommandValidator()
  {
    RuleFor(x => x.Name)
      .NotEmpty()
      .MaximumLength(100);

    RuleFor(x => x.Location)
      .NotEmpty()
      .MaximumLength(100);

    RuleFor(x => x.Venue)
      .NotEmpty()
      .MaximumLength(100);

    RuleFor(x => x.StartDate)
      .NotEmpty();

    RuleFor(x => x.EndDate)
      .Must((command, endDate) => endDate >= command.StartDate);
  }
}
