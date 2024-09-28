// <copyright file="GetMeetQuery.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Application.Meets.Queries.GetMeet;

public sealed record GetMeetQuery(Guid Id) : IQuery<GetMeetResponse>;
