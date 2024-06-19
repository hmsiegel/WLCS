// <copyright file="IQueryHandler.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Application.Messages;

/// <summary>
/// Represents a query handler.
/// </summary>
/// <typeparam name="TQuery">The query.</typeparam>
/// <typeparam name="TResponse">The response.</typeparam>
public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
  where TQuery : IQuery<TResponse>;
