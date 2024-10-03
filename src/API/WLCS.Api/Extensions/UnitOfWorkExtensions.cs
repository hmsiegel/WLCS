// <copyright file="UnitOfWorkExtensions.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Api.Extensions;

public static class UnitOfWorkExtensions
{
  public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
  {
    services.AddKeyedScoped<IUnitOfWork, CommunicationDbContext>(ModuleNames.Communication);
    services.AddKeyedScoped<IUnitOfWork, AdministrationDbContext>(ModuleNames.Administration);
    services.AddKeyedScoped<IUnitOfWork, CompetitionsDbContext>(ModuleNames.Competitions);
    services.AddKeyedScoped<IUnitOfWork, AthletesDbContext>(ModuleNames.Athletes);

    return services;
  }
}
