// <copyright file="GetMeetsQuery.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

using WLCS.Modules.Competitions.Application.Meets.Queries.GetMeet;

namespace WLCS.Modules.Competitions.Application.Meets.Queries.GetMeets;

public sealed record GetMeetsQuery : IQuery<IReadOnlyCollection<MeetResponse>>;
