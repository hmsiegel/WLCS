// <copyright file="CompetitionsUnitOfWorkBehavior.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Application.Behaviors;

public sealed class CompetitionsUnitOfWorkBehavior<TRequest, TResponse>
  ([FromKeyedServices("competitions")] IUnitOfWork unitOfWork)
  : UnitOfWorkBehavior<TRequest, TResponse>(unitOfWork)
  where TRequest : notnull
{
}
