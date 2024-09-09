// <copyright file="GenericArrayHandler.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Infrastructure.Data;

internal sealed class GenericArrayHandler<T> : SqlMapper.TypeHandler<T[]>
{
  public override T[]? Parse(object value)
  {
    return value as T[];
  }

  public override void SetValue(IDbDataParameter parameter, T[]? value)
  {
    parameter.Value = value;
  }
}
