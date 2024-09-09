// <copyright file="Program.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

var builder = WebApplication.CreateBuilder(args);
{
  builder.Host.UseSerilog((context, loggerConfiguration)
    => loggerConfiguration.ReadFrom.Configuration(context.Configuration));

  builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
  builder.Services.AddProblemDetails();

  builder.Services.AddEndpointsApiExplorer();
  builder.Services.AddSwaggerDocumentation();

  Assembly[] applicationAssemblies =
  [
    WLCS.Modules.Competitions.Application.AssemblyReference.Assembly,
    WLCS.Modules.Administration.Application.AssemblyReference.Assembly,
    WLCS.Modules.Athletes.Application.AssemblyReference.Assembly
  ];

  builder.Services.AddApplication(applicationAssemblies);

  var databaseConnectionString = builder.Configuration.GetConnectionStringOrThrow("Database")!;
  var redisConnectionString = builder.Configuration.GetConnectionStringOrThrow("Cache")!;

  builder.Services.AddInfrastructure(
    [
    CompetitionModule.ConfigureConsumers
    ],
    databaseConnectionString,
    redisConnectionString);

  Uri keyCloakHealthUri = builder.Configuration.GetKeyCloakHealthUrl();

  builder.Configuration.AddModuleConfiguration(["competitions", "administration", "athletes"]);

  builder.Services.AddHealthChecks()
    .AddNpgSql(databaseConnectionString)
    .AddRedis(redisConnectionString)
    .AddKeyCloak(keyCloakHealthUri);

  builder.Services.AddCompetitionModule(builder.Configuration);
  builder.Services.AddAdministrationModule(builder.Configuration);
  builder.Services.AddAthletesModules(builder.Configuration);
}

var app = builder.Build();
{
  if (app.Environment.IsDevelopment())
  {
    app.UseSwagger();
    app.UseSwaggerUI();

    app.ApplyMigrations();
  }

  app.MapEndpoints();

  app.MapHealthChecks("health", new HealthCheckOptions
  {
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse,
  });

  app.UseSerilogRequestLogging();

  app.UseExceptionHandler();

  app.UseAuthentication();

  app.UseAuthorization();

  app.Run();
}
