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

      options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
      {
        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
      });

      options.AddSecurityRequirement(new OpenApiSecurityRequirement
      {
        {
          new OpenApiSecurityScheme
          {
            Reference = new OpenApiReference
            {
              Type = ReferenceType.SecurityScheme,
              Id = "Bearer",
            },
            Scheme = "oauth2",
            Name = "Bearer",
            In = ParameterLocation.Header,
          },
          new List<string>()
        },
      });

      options.CustomSchemaIds(x => x.FullName?.Replace("+", ".", StringComparison.InvariantCultureIgnoreCase));
    });

    return services;
  }
}
