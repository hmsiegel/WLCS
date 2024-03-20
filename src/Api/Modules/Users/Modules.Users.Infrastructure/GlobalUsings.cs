global using Application.Behaviors;
global using Application.Data;
global using Application.EventBus;
global using Application.Messaging;
global using Application.Time;

global using Authorization.Contracts;

global using Domain.Primitives;

global using Endpoints.Extensions;

global using FluentValidation;

global using Infrastructure.BackgroundJobs;
global using Infrastructure.Configuration;
global using Infrastructure.EventBus;
global using Infrastructure.Extensions;
global using Infrastructure.Utilities;

global using MassTransit;

global using MediatR;

global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Http;
global using Microsoft.AspNetCore.Routing;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.Caching.Memory;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.DependencyInjection.Extensions;
global using Microsoft.Extensions.Options;

global using Modules.Users.Endpoints;
global using Modules.Users.Infrastructure.Authorization.Permissions;
global using Modules.Users.Infrastructure.Authorization.SameUser.AuthorizationHandlers;
global using Modules.Users.Infrastructure.Authorization.SameUser.Options;
global using Modules.Users.Infrastructure.Authorization.SameUser.Requirements;
global using Modules.Users.Infrastructure.Authorization.SameUser.Services;
global using Modules.Users.Infrastructure.BackgroundJobs.ProcessInboxMessages;
global using Modules.Users.Infrastructure.BackgroundJobs.ProcessOutboxMessages;
global using Modules.Users.Infrastructure.Idempotence;
global using Modules.Users.Persistence;
global using Modules.Users.Persistence.Constants;

global using Newtonsoft.Json;

global using Persistence.Extensions;
global using Persistence.Inbox;
global using Persistence.Interceptors;
global using Persistence.Options;

global using Polly;
global using Polly.Retry;

global using Quartz;

global using Scrutor;

global using Shared.Extensions;

global using System.Collections.Concurrent;
global using System.Reflection;
