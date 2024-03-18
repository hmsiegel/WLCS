global using Authorization.AuthorizationHandlers;
global using Authorization.AuthorizationPolicyProviders;
global using Authorization.Contracts;
global using Authorization.Extensions;
global using Authorization.Options;
global using Authorization.Requirements;
global using Authorization.Services;

global using Infrastructure.Configuration;
global using Infrastructure.EventBus;

global using MassTransit;

global using Microsoft.AspNetCore.Authorization;
global using Microsoft.Extensions.Caching.Memory;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Options;

global using System.Reflection;
global using System.Security.Claims;
