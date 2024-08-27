// <copyright file="SearchMeetsQuery.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Application.Meets.Queries.SearchMeets;

public sealed record SearchMeetsQuery(
  CompetitionId? CompetitionId,
  DateOnly? StartDate,
  DateOnly? EndDate,
  int Page,
  int PageSize) : IQuery<SearchMeetsResponse>;
