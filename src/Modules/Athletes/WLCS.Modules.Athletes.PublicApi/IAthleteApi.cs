// <copyright file="IAthleteApi.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Athletes.PublicApi;

public interface IAthleteApi
{
  Task<AthleteResponse?> GetAsync(Guid userId, CancellationToken cancellationToken = default);
}
