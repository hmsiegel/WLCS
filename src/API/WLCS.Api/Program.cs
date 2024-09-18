// <copyright file="Program.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

var builder = WebApplication.CreateBuilder(args);
{
  var logger = Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.Console(formatProvider: CultureInfo.CurrentCulture)
    .CreateLogger();

  logger.Information("Starting web host");

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
    WLCS.Modules.Athletes.Application.AssemblyReference.Assembly,
    WLCS.Modules.Communication.Application.AssemblyReference.Assembly
  ];

  builder.Services.AddApplication(applicationAssemblies);

  var databaseConnectionString = builder.Configuration.GetConnectionStringOrThrow("Database")!;
  var redisConnectionString = builder.Configuration.GetConnectionStringOrThrow("Cache")!;
  var rabbitMqSettings = new RabbitMqSettings(builder.Configuration.GetConnectionString("Queue")!);
  var mongoConnectionString = builder.Configuration.GetConnectionString("Mongo")!;

  builder.Services.AddInfrastructure(
    DiagnosticsConfig.ServiceName,
    [
    CompetitionModule.ConfigureConsumers
    ],
    rabbitMqSettings,
    databaseConnectionString,
    redisConnectionString,
    mongoConnectionString);

  Uri keyCloakHealthUrl = builder.Configuration.GetKeyCloakHealthUrl();

  builder.Services.AddHealthChecks()
    .AddNpgSql(databaseConnectionString)
    .AddRedis(redisConnectionString)
    .AddMongoDb(mongoConnectionString)
    .AddRabbitMQ(rabbitConnectionString: rabbitMqSettings.Host)
    .AddKeyCloak(keyCloakHealthUrl);

  builder.Configuration.AddModuleConfiguration(["competitions", "administration", "athletes", "communication"]);

  builder.Services.AddCompetitionModule(logger, builder.Configuration);
  builder.Services.AddAdministrationModule(logger, builder.Configuration);
  builder.Services.AddAthletesModule(logger, builder.Configuration);
  builder.Services.AddCommunicationModule(logger, builder.Configuration);
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

  app.UseLogContextTraceLogging();

  app.UseSerilogRequestLogging();

  app.UseExceptionHandler();

  app.UseAuthentication();

  app.UseAuthorization();

  app.Run();
}

public partial class Program
{
  protected Program()
  {
  }
}
