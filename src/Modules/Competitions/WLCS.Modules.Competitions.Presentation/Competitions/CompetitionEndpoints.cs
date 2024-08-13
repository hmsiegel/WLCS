// <copyright file="CompetitionEndpoints.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Presentation.Competitions;

public static class CompetitionEndpoints
{
  public static void MapEndpoints(IEndpointRouteBuilder app)
  {
    CreateCompetition.MapEndpoint(app);
  }
}
