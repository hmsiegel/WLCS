// <copyright file="ModuleExtensions.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Api.Extensions;

public static class ModuleExtensions
{
  public static void AddModules(this IServiceCollection services, IConfiguration configuration)
  {
    ArgumentNullException.ThrowIfNull(configuration);

    services.AddCompetitionModule(Log.Logger, configuration);
    services.AddAdministrationModule(Log.Logger, configuration);
    services.AddAthletesModule(Log.Logger, configuration);
    services.AddCommunicationModule(Log.Logger, configuration);
  }
}
