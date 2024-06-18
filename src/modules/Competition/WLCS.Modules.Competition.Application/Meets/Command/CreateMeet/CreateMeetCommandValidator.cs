// <copyright file="CreateMeetCommandValidator.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competition.Application.Meets.Command.CreateMeet;

/// <summary>
/// Validates the <see cref="CreateMeetCommand"/>.
/// </summary>
internal sealed class CreateMeetCommandValidator : AbstractValidator<CreateMeetCommand>
{
  /// <summary>
  /// Initializes a new instance of the <see cref="CreateMeetCommandValidator"/> class.
  /// </summary>
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
      .NotEmpty()
      .GreaterThan(x => x.StartDate);
  }
}
