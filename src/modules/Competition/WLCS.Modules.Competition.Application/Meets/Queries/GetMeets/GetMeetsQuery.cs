// <copyright file="GetMeetsQuery.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competition.Application.Meets.Queries.GetMeets;

/// <summary>
/// Gets all meets.
/// </summary>
public sealed record GetMeetsQuery : IQuery<IReadOnlyCollection<MeetResponse>>;
