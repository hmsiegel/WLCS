// <copyright file="SearchMeetsResponse.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

using WLCS.Modules.Competitions.Application.Meets.Queries.GetMeets;

namespace WLCS.Modules.Competitions.Application.Meets.Queries.SearchMeets;

public sealed record SearchMeetsResponse(
  int Page,
  int PageSize,
  int TotalCount,
  IReadOnlyCollection<MeetResponse> Meets);
