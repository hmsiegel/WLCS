// <copyright file="SerializerSettings.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Infrastructure.Serialization;

public static class SerializerSettings
{
  public static readonly JsonSerializerSettings Instance = new()
  {
    TypeNameHandling = TypeNameHandling.All,
    MetadataPropertyHandling = MetadataPropertyHandling.ReadAhead,
  };
}
