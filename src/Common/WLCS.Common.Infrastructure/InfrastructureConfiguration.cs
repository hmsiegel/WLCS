// <copyright file="InfrastructureConfiguration.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Infrastructure;

public static class InfrastructureConfiguration
{
  private const string DefaultSchedulerId = "default-id";
  private const string DefaultSchedulerName = "default-name";

  public static IServiceCollection AddInfrastructure(
    this IServiceCollection services,
    string serviceName,
    Action<IRegistrationConfigurator, string>[] moduleConfigureConsumers,
    RabbitMqSettings rabbitMqSettings,
    string databaseConnectionString,
    string redisConnectionString,
    string mongoConnectionString)
  {
    services.AddAuthenticationInternal();

    services.AddAuthorizationInternal();

    var npgsqlDataSource = new NpgsqlDataSourceBuilder(databaseConnectionString).Build();
    services.TryAddSingleton(npgsqlDataSource);

    services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();

    SqlMapper.AddTypeHandler(new GenericArrayHandler<string>());

    services.TryAddSingleton<IDateTimeProvider, DateTimeProvider>();

    services.TryAddSingleton<InsertOutboxMessagesInterceptor>();

    services.AddQuartz(configurator =>
    {
      var scheduler = Guid.NewGuid();
      configurator.SchedulerId = $"{DefaultSchedulerId}-{scheduler}";
      configurator.SchedulerName = $"{DefaultSchedulerName}-{scheduler}";
    });

    services.AddQuartzHostedService(options => options.WaitForJobsToComplete = true);

    try
    {
      IConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect(redisConnectionString);
      services.TryAddSingleton(connectionMultiplexer);

      services.AddStackExchangeRedisCache(options =>
        options.ConnectionMultiplexerFactory = () => Task.FromResult(connectionMultiplexer));
    }
    catch
    {
      services.AddDistributedMemoryCache();
    }

    services.TryAddSingleton<ICacheService, CacheService>();

    services.TryAddSingleton<IEventBus, EventBus.EventBus>();

    services.AddMassTransit(configure =>
    {
      var instanceId = serviceName.ToLowerInvariant().Replace('.', '-');
      foreach (Action<IRegistrationConfigurator, string> configureConsumer in moduleConfigureConsumers)
      {
        configureConsumer(configure, instanceId);
      }

      configure.SetKebabCaseEndpointNameFormatter();

      configure.UsingRabbitMq((context, cfg) =>
      {
        cfg.Host(new Uri(rabbitMqSettings.Host), h =>
        {
          h.Username(rabbitMqSettings.Username);
          h.Password(rabbitMqSettings.Password);
        });

        cfg.ConfigureEndpoints(context);
      });
    });

    services
      .AddOpenTelemetry()
      .ConfigureResource(resource => resource.AddService(serviceName))
      .WithTracing(tracing =>
      {
        tracing
          .AddAspNetCoreInstrumentation()
          .AddHttpClientInstrumentation()
          .AddEntityFrameworkCoreInstrumentation()
          .AddRedisInstrumentation()
          .AddNpgsql()
          .AddSource(MassTransit.Logging.DiagnosticHeaders.DefaultListenerName)
          .AddSource("MongoDB.Driver.Core.Extensions.DiagnosticSources");

        tracing.AddOtlpExporter();
      });

    var mongoClientSettings = MongoClientSettings.FromConnectionString(mongoConnectionString);

    mongoClientSettings.ClusterConfigurator = c => c.Subscribe(
      new DiagnosticsActivityEventSubscriber(
        new InstrumentationOptions
        {
          CaptureCommandText = true,
        }));

    services.AddSingleton<IMongoClient>(new MongoClient(mongoClientSettings));

#pragma warning disable CS0618 // Type or member is obsolete
    BsonDefaults.GuidRepresentation = GuidRepresentation.Standard;
    BsonDefaults.GuidRepresentationMode = GuidRepresentationMode.V3;
#pragma warning restore CS0618 // Type or member is obsolete

    BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));

    return services;
  }
}
