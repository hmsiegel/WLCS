// <copyright file="GlobalUsings.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>
global using System.Net;
global using System.Net.Http.Headers;
global using System.Net.Http.Json;
global using System.Text.Json.Serialization;

global using Bogus;

global using FluentAssertions;

global using MediatR;

global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.AspNetCore.Hosting;
global using Microsoft.AspNetCore.Mvc.Testing;
global using Microsoft.AspNetCore.TestHost;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Options;

global using Testcontainers.Keycloak;
global using Testcontainers.PostgreSql;
global using Testcontainers.Redis;

global using WLCS.Common.Domain;
global using WLCS.Modules.Administration.Application.Users.Commands.RegisterUser;
global using WLCS.Modules.Administration.Application.Users.Commands.UpdateUser;
global using WLCS.Modules.Administration.Application.Users.Queries.GetUser;
global using WLCS.Modules.Administration.Application.Users.Queries.GetUserPermissions;
global using WLCS.Modules.Administration.Domain.Users;
global using WLCS.Modules.Administration.Infrastructure.Database;
global using WLCS.Modules.Administration.Infrastructure.Identity;
global using WLCS.Modules.Administration.IntegrationTests.Abstractions;
global using WLCS.Modules.Administration.Presentation.Users;
