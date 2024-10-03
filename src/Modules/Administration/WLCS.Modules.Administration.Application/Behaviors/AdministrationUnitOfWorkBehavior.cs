// <copyright file="AdministrationUnitOfWorkBehavior.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Application.Behaviors;

internal sealed class AdministrationUnitOfWorkBehavior<TRequest, TResponse>([FromKeyedServices("administration")] IUnitOfWork unitOfWork)
  : UnitOfWorkBehavior<TRequest, TResponse>(unitOfWork)
  where TRequest : notnull
{
}
