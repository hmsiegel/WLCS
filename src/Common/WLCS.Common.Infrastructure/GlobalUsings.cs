// <copyright file="GlobalUsings.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

global using System.Buffers;
global using System.Data.Common;
global using System.Security.Claims;
global using System.Text.Json;

global using MassTransit;

global using MediatR;

global using Microsoft.AspNetCore.Authentication;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Diagnostics;
global using Microsoft.Extensions.Caching.Distributed;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.DependencyInjection.Extensions;
global using Microsoft.Extensions.Options;

global using Npgsql;

global using StackExchange.Redis;

global using WLCS.Common.Application.Authorization;
global using WLCS.Common.Application.Caching;
global using WLCS.Common.Application.Clock;
global using WLCS.Common.Application.Data;
global using WLCS.Common.Application.EventBus;
global using WLCS.Common.Application.Exceptions;
global using WLCS.Common.Domain;
global using WLCS.Common.Infrastructure.Authentication;
global using WLCS.Common.Infrastructure.Authorization;
global using WLCS.Common.Infrastructure.Caching;
global using WLCS.Common.Infrastructure.Clock;
global using WLCS.Common.Infrastructure.Data;
global using WLCS.Common.Infrastructure.Interceptors;
