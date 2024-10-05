// <copyright file="UpdatePlatformCommandValidator.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Application.Platforms.Commands.UpdatePlatform;

internal sealed class UpdatePlatformCommandValidator : AbstractValidator<UpdatePlatformCommand>
{
  public UpdatePlatformCommandValidator()
  {
    RuleFor(x => x.PlatformId)
      .NotEmpty()
      .WithMessage("PlatformId is required.");

    RuleFor(x => x.PlatformName)
      .NotEmpty()
      .WithMessage("PlatformName is required.");
  }
}
