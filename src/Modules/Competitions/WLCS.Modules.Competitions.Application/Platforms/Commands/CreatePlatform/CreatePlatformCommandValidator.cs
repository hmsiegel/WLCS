// <copyright file="CreatePlatformCommandValidator.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Application.Platforms.Commands.CreatePlatform;

internal sealed class CreatePlatformCommandValidator : CustomValidator<CreatePlatformCommand>
{
  public CreatePlatformCommandValidator()
  {
    RuleFor(x => x.Name)
      .NotEmpty()
      .MaximumLength(PlatformName.MaxLength);

    RuleFor(x => x.MeetId)
      .NotEmpty();
  }
}
