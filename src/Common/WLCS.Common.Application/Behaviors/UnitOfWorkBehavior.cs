// <copyright file="UnitOfWorkBehavior.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Application.Behaviors;

public class UnitOfWorkBehavior<TRequest, TResponse>(IUnitOfWork unitOfWork)
  : IPipelineBehavior<TRequest, TResponse>
  where TRequest : notnull
{
  private readonly IUnitOfWork _unitOfWork = unitOfWork;

  public async Task<TResponse> Handle(
    TRequest request,
    RequestHandlerDelegate<TResponse> next,
    CancellationToken cancellationToken)
  {
    ArgumentNullException.ThrowIfNull(next);

    if (IsNotCommand())
    {
      return await next();
    }

    using var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

    var response = await next();

    await _unitOfWork.SaveChangesAsync(cancellationToken);

    transactionScope.Complete();

    return response;
  }

  private static bool IsNotCommand()
  {
    return !typeof(TRequest).Name.EndsWith("Command", StringComparison.InvariantCulture);
  }
}
