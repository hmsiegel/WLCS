// <copyright file="Program.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>
var logger = Log.Logger = new LoggerConfiguration()
  .Enrich.FromLogContext()
  .WriteTo.Console(formatProvider: CultureInfo.InvariantCulture)
  .CreateLogger();

logger.Information("Starting application.");

var builder = WebApplication.CreateBuilder(args);
{
  builder.Host.UseSerilog((context, loggerConfig) =>
    loggerConfig.ReadFrom.Configuration(context.Configuration));

  builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
  builder.Services.AddProblemDetails();
  builder.Services.AddEndpointsApiExplorer();
  builder.Services.AddSwaggerGen(options =>
  {
    options.CustomSchemaIds(t => t.FullName?.Replace("+", ".", StringComparison.InvariantCultureIgnoreCase));
  });

  Assembly[] applicationAssemblies = [
      WLCS.Modules.Competition.Application.AssemblyReference.Application,
      WLCS.Modules.Administration.Application.AssemblyReference.Application,
      WLCS.Modules.Scheduling.Application.AssemblyReference.Application,
      WLCS.Modules.Results.Application.AssemblyReference.Application,
      WLCS.Modules.Communication.Application.AssemblyReference.Application,
      WLCS.Modules.Athletes.Application.AssemblyReference.Application,
    ];

  builder.Services.AddApplication(applicationAssemblies);

  var databaseConnectionString = builder.Configuration.GetConnectionString("Database")!;
  var redisConnectionString = builder.Configuration.GetConnectionString("Cache")!;

  builder.Services.AddInfrastructure(
    databaseConnectionString,
    redisConnectionString);

  string[] configurations = ["competition", "administration", "athletes", "communication", "results", "scheduling"];

  builder.Configuration.AddModuleConfiguration(configurations);

  builder.Services.AddHealthChecks()
    .AddNpgSql(databaseConnectionString)
    .AddRedis(redisConnectionString)
    .AddUrlGroup(new Uri(builder.Configuration.GetValue<string>("KeyCloak:HealthUrl")!), HttpMethod.Get, "keycloak");

  builder.Services.AddAdministrationModule(builder.Configuration, logger);
  builder.Services.AddCompetitionModule(builder.Configuration, logger);
  builder.Services.AddAthletesModule(builder.Configuration, logger);
  builder.Services.AddCommunicationModule(builder.Configuration, logger);
  builder.Services.AddResultsModule(builder.Configuration, logger);
  builder.Services.AddSchedulingModule(builder.Configuration, logger);
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

  app.UseAuthentication()
    .UseAuthorization();

  app.Run();
}
