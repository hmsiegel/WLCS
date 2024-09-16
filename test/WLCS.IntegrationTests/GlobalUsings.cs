// <copyright file="GlobalUsings.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>
global using System.Security.Claims;
global using System.Text.Encodings.Web;

global using Bogus;

global using MediatR;

global using Microsoft.AspNetCore.Authentication;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Hosting;
global using Microsoft.AspNetCore.Mvc.Testing;
global using Microsoft.AspNetCore.TestHost;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Logging;
global using Microsoft.Extensions.Options;

global using Testcontainers.Keycloak;
global using Testcontainers.PostgreSql;
global using Testcontainers.Redis;

global using WLCS.Common.Domain;
global using WLCS.IntegrationTests.Abstractions;
global using WLCS.IntegrationTests.MockAuthentication;
global using WLCS.Modules.Administration.Infrastructure.Identity;
