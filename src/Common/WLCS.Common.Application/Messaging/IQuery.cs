// <copyright file="IQuery.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Application.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;
