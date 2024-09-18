﻿// <copyright file="IUnitOfWork.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Communication.Application.Abstractions.Data;

public interface IUnitOfWork
{
  Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
