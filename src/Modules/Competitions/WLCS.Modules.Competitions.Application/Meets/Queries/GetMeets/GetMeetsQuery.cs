// <copyright file="GetMeetsQuery.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Application.Meets.Queries.GetMeets;

public sealed record GetMeetsQuery : IQuery<IReadOnlyCollection<MeetResponse>>;
