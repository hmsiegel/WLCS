// <copyright file="ICommandHandler.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Application.Messages;

/// <summary>
/// Represents a command handler.
/// </summary>
/// <typeparam name="TCommand">The command associasted with the command handler.</typeparam>
public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand, Result>
  where TCommand : ICommand;

/// <summary>
/// Represents a command handler.
/// </summary>
/// <typeparam name="TCommand">The command associasted with the command handler.</typeparam>
/// <typeparam name="TResponse">The response.</typeparam>
public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, Result<TResponse>>
  where TCommand : ICommand<TResponse>;
