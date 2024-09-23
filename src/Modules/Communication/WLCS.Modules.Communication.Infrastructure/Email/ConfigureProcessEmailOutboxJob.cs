// <copyright file="ConfigureProcessEmailOutboxJob.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Communication.Infrastructure.Email;

internal sealed class ConfigureProcessEmailOutboxJob(IOptions<OutboxOptions> outboxOptions) : IConfigureOptions<QuartzOptions>
{
  private readonly OutboxOptions _outboxOptions = outboxOptions.Value;

  public void Configure(QuartzOptions options)
  {
    var jobName = typeof(ProcessEmailOutboxJob).FullName!;

    options
      .AddJob<ProcessEmailOutboxJob>(configure => configure.WithIdentity(jobName))
      .AddTrigger(configure =>
        configure
          .ForJob(jobName)
          .WithSimpleSchedule(schedule =>
            schedule
              .WithIntervalInSeconds(_outboxOptions.IntervalInSeconds)
              .RepeatForever()));
  }
}
