// <copyright file="CommunicationUnitOfWorkBehavior.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Communication.Application.Behaviors;

public sealed class CommunicationUnitOfWorkBehavior<TRequest, TResponse>
  ([FromKeyedServices("communication")] IUnitOfWork unitOfWork)
  : UnitOfWorkBehavior<TRequest, TResponse>(unitOfWork)
  where TRequest : notnull
{
}
