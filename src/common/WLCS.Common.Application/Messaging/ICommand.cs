// <copyright file="ICommand.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Application.Messaging;

/// <summary>
/// Represents a command.
/// </summary>
public interface ICommand : IRequest<Result>, IBaseCommand;

/// <summary>
/// Represents a command.
/// </summary>
/// <typeparam name="TResponse">The response.</typeparam>
public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand;

/// <summary>
/// Represents a command.
/// </summary>
public interface IBaseCommand;
