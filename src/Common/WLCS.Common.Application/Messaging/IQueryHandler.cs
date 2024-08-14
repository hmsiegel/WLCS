// <copyright file="IQueryHandler.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Application.Messaging;

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>;
