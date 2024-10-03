// <copyright file="AthletesUnitOfWorkBehavior.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Athletes.Application.Behaviors;

public sealed class AthletesUnitOfWorkBehavior<TRequest, TResponse>
  ([FromKeyedServices("athletes")] IUnitOfWork unitOfWork)
  : UnitOfWorkBehavior<TRequest, TResponse>(unitOfWork)
  where TRequest : notnull
{
}
