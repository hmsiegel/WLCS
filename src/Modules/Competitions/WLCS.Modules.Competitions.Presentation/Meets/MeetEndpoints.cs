// <copyright file="MeetEndpoints.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Presentation.Meets;

public static class MeetEndpoints
{
  public static void MapEndpoints(IEndpointRouteBuilder app)
  {
    CreateMeet.MapEndpoint(app);
    GetMeet.MapEndpoint(app);
    GetMeets.MapEndpoint(app);
  }
}
