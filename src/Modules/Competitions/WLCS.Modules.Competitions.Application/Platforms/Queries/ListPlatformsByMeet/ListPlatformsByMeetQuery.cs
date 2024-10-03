// <copyright file="ListPlatformsByMeetQuery.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Application.Platforms.Queries.ListPlatformsByMeet;

public sealed record ListPlatformsByMeetQuery(Guid MeetId) : IQuery<List<GetPlatformResponse>>;
