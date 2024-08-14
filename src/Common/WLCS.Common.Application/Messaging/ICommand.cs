// <copyright file="ICommand.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Application.Messaging;

public interface ICommand : IRequest<Result>, IBaseCommand;

public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand;

public interface IBaseCommand;
