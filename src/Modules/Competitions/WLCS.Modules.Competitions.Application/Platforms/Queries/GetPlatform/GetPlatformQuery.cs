// <copyright file="GetPlatformQuery.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Application.Platforms.Queries.GetPlatform;

public sealed record GetPlatformQuery(Guid PlatformId) : IQuery<GetPlatformResponse>;
