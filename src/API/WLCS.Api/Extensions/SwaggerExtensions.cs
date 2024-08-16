// <copyright file="SwaggerExtensions.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Api.Extensions;

internal static class SwaggerExtensions
{
  internal static void AddSwaggerDocument(this IServiceCollection services)
  {
    services.AddSwaggerGen(options =>
    {
      options.CustomSchemaIds(t => t.FullName?.Replace(
        "+",
        ".",
        StringComparison.InvariantCulture));
    });

    services.SwaggerDocument(o =>
    {
      o.DocumentSettings = s =>
      {
        s.Title = "WLCS API";
        s.Version = "v1";
      };
    });
  }
}
