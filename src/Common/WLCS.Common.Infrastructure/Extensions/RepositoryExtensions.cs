// <copyright file="RepositoryExtensions.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Infrastructure.Extensions;

public static class RepositoryExtensions<T>
  where T : class
{
  private const string RepositorySuffix = "Repository";

  public static void RegisterRepositories(IServiceCollection services)
  {
    services.Scan(scan => scan
      .FromAssemblyOf<T>()
      .AddClasses(classes => classes.Where(type => type.Name.EndsWith(RepositorySuffix, StringComparison.InvariantCulture)))
        .UsingRegistrationStrategy(registrationStrategy: RegistrationStrategy.Skip)
        .AsImplementedInterfaces()
        .WithScopedLifetime());
  }
}
