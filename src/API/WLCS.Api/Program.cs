// <copyright file="Program.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

StaticLogger.EnsureInitialized();
Log.Information("Starting web host");
try
{
  var builder = WebApplication.CreateBuilder(args);
  {
    builder.AddModuleConfiguration(["competitions", "administration", "athletes", "communication"]);
    builder.RegisterSerilog();

    builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
    builder.Services.AddProblemDetails();

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerDocumentation();

    builder.Services.AddApplication(StaticAssemblies.ApplicationAssemblies);

    builder.Services.AddMappings(StaticAssemblies.PresentationAssemblies);

    var databaseConnectionString = builder.Configuration.GetConnectionStringOrThrow("Database");
    var redisConnectionString = builder.Configuration.GetConnectionStringOrThrow("Cache");
    var rabbitMqSettings = new RabbitMqSettings(builder.Configuration.GetConnectionStringOrThrow("Queue"));
    var mongoConnectionString = builder.Configuration.GetConnectionStringOrThrow("Mongo");

    builder.Services.AddInfrastructure(
      DiagnosticsConfig.ServiceName,
      [
      CompetitionModule.ConfigureConsumers,
    CommunicationModule.ConfigureConsumers,
      ],
      rabbitMqSettings,
      databaseConnectionString,
      redisConnectionString,
      mongoConnectionString);

    builder.Services.AddFastEndpoints(opt => opt.Assemblies = StaticAssemblies.PresentationAssemblies);

    Uri keyCloakHealthUrl = builder.Configuration.GetKeyCloakHealthUrl();

    builder.Services.AddHealthChecks()
      .AddNpgSql(databaseConnectionString)
      .AddRedis(redisConnectionString)
      .AddMongoDb(mongoConnectionString)
      .AddRabbitMQ(rabbitConnectionString: rabbitMqSettings.Host)
      .AddKeyCloak(keyCloakHealthUrl);

    builder.Services.AddModules(builder.Configuration);
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

    app.UseFastEndpoints()
      .UseSwaggerGen();

    app.Run();
  }
}
catch (Exception ex) when (!ex.GetType().Name.Equals("StopTheHostException", StringComparison.Ordinal))
{
  StaticLogger.EnsureInitialized();
  Log.Fatal(ex, "Unhandled exception");
}
finally
{
  StaticLogger.EnsureInitialized();
  Log.Information("Stopping web host");
  Log.CloseAndFlush();
}

public partial class Program
{
  protected Program()
  {
  }
}
