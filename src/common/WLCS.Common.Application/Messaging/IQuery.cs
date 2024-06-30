// <copyright file="IQuery.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Application.Messaging;

/// <summary>
/// Represents a query.
/// </summary>
/// <typeparam name="TResponse">The response of the query.</typeparam>
public interface IQuery<TResponse> : IRequest<Result<TResponse>>;
