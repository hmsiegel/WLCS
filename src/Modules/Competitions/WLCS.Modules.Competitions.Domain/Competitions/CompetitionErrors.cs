// <copyright file="CompetitionErrors.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Domain.Competitions;

public static class CompetitionErrors
{
  public static Error NotFound(Guid competitionId) => Error.NotFound(
    "CompetitionErrors.NotFound",
    $"The competition with Id {competitionId} was not found.");
}
