// <copyright file="SwaggerExtensions.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Api.Extensions;

internal static class SwaggerExtensions
{
  internal static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
  {
    services.AddSwaggerGen(options =>
    {
      options.SwaggerDoc("v1", new OpenApiInfo
      {
        Title = "WLCS API",
        Version = "v1",
        Contact = new OpenApiContact
        {
          Name = "Harlan Siegel",
          Email = "harlan@siegel.com",
        },
        Description = "API for the WLCS application.",
        License = new OpenApiLicense
        {
          Name = "MIT",
          Url = new Uri($"https://opensource.org/licenses/MIT"),
        },
      });

      options.CustomSchemaIds(x => x.FullName?.Replace("+", ".", StringComparison.InvariantCultureIgnoreCase));
    });

    return services;
  }
}
